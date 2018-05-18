using System;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Donker.Extensions.Mvc.ModelBinding
{
    /// <summary>
    /// Decorator class for catching <see cref="HttpRequestValidationException"/>s thrown for possibly malicious requests and replacing these with model errors instead when the model class or a property specified the <see cref="MaliciousRequestMessageAttribute"/>.
    /// </summary>
    public class MaliciousRequestModelBinder : IModelBinder
    {
        private readonly IModelBinder _modelBinder;

        /// <summary>
        /// Initializes a new instance of <see cref="MaliciousRequestModelBinder"/>, that decorates the specified model binder.
        /// </summary>
        /// <param name="modelBinder">The model binder to decorate.</param>
        /// <exception cref="ArgumentNullException"><paramref name="modelBinder"/> is null.</exception>
        public MaliciousRequestModelBinder(IModelBinder modelBinder)
        {
            if (modelBinder == null)
                throw new ArgumentNullException("modelBinder", "The model binder cannot be null.");

            _modelBinder = modelBinder;
        }

        /// <summary>
        /// Binds the model to a value by using the specified controller context and binding context.
        /// <see cref="HttpRequestValidationException"/>s are converted to model errors if the <see cref="MaliciousRequestMessageAttribute"/> is specified for the model's class or property.
        /// </summary>
        /// <param name="controllerContext">The controller context.</param>
        /// <param name="bindingContext">The binding context.</param>
        /// <returns>The bound value.</returns>
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            try
            {
                return _modelBinder.BindModel(controllerContext, bindingContext);
            }
            catch (HttpRequestValidationException)
            {
                var attribute = GetMaliciousRequestMessageAttribute(bindingContext);

                if (attribute == null)
                    throw;

                bindingContext.ModelState.AddModelError(
                    bindingContext.ModelName,
                    attribute.Message);
            }

            IUnvalidatedValueProvider provider = bindingContext.ValueProvider as IUnvalidatedValueProvider;

            if (provider == null)
                return null;

            ValueProviderResult valueProviderResult = provider.GetValue(bindingContext.ModelName, true);

            if (valueProviderResult == null)
                return null;

            return valueProviderResult.AttemptedValue;
        }

        private MaliciousRequestMessageAttribute GetMaliciousRequestMessageAttribute(ModelBindingContext bindingContext)
        {
            Type modelType = bindingContext.ModelMetadata.ContainerType;

            if (modelType == null)
                return null;

            PropertyInfo propertyInfo = modelType.GetProperty(bindingContext.ModelMetadata.PropertyName);

            MaliciousRequestMessageAttribute attribute = null;

            if (propertyInfo != null)
                attribute = propertyInfo.GetCustomAttribute<MaliciousRequestMessageAttribute>();

            return attribute ?? modelType.GetCustomAttribute<MaliciousRequestMessageAttribute>();
        }
    }

    /// <summary>
    /// Attribute to use together with the <see cref="MaliciousRequestModelBinder"/> in order to determine the model error message to show at runtime.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class MaliciousRequestMessageAttribute : Attribute
    {
        private readonly Func<string> _messageFunc;

        /// <summary>
        /// Gets the message that is determined at runtime.
        /// </summary>
        public string Message
        {
            get { return _messageFunc.Invoke(); }
        }

        /// <summary>
        /// Initializes a new instance of <see cref="MaliciousRequestMessageAttribute"/> that returns the specified message.
        /// </summary>
        /// <param name="message">The message to return at runtime.</param>
        public MaliciousRequestMessageAttribute(string message)
        {
            if (message == null)
                message = string.Empty;

            _messageFunc = () => message;
        }

        /// <summary>
        /// Initiates a new instance of <see cref="MaliciousRequestMessageAttribute"/> where the message returned is retrieved from a resource class at runtime.
        /// </summary>
        /// <param name="messageResourceType">The type containing the property that returns the error message.</param>
        /// <param name="messageResourceName">The name of the resource's property containing the error message to return at runtime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="messageResourceType"/> or <paramref name="messageResourceName"/> is null.</exception>
        /// /// <exception cref="ArgumentException"><paramref name="messageResourceName"/> is empty, could not be found or does not have an accessible getter.</exception>
        public MaliciousRequestMessageAttribute(Type messageResourceType, string messageResourceName)
        {
            if (messageResourceType == null)
                throw new ArgumentNullException("messageResourceType", "The message resource type cannot be null.");
            if (messageResourceName == null)
                throw new ArgumentNullException("messageResourceName", "The message resource name cannot be null.");
            if (messageResourceName.Length == 0)
                throw new ArgumentException("The message resource type cannot be empty.", "messageResourceName");

            PropertyInfo property = messageResourceType.GetProperty(
                messageResourceName,
                BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            if (property == null)
                throw new ArgumentException("No static property could be found for the specified message resource name.", "messageResourceName");

            MethodInfo getMethod = property.GetGetMethod(true);
            if (getMethod == null || (!getMethod.IsAssembly && !getMethod.IsPublic))
                throw new ArgumentException("The property specified in the message resource name does not have an accessible getter.", "messageResourceName");

            _messageFunc = () =>
            {
                string message = null;
                object messageObj = property.GetValue(null);
                if (messageObj != null)
                    message = messageObj.ToString();
                return message ?? string.Empty;
            };
        }
    }
}