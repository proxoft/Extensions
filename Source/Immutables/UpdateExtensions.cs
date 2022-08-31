using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Proxoft.Extensions.Immutables
{
    public static class UpdateExtensions
    {
        /// <summary>
        /// Use this method as a shorcut for using private update actions.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="immutable">Immutable to be updated</param>
        /// <param name="updateAction">Action that will be executed with the cloned immutable</param>
        /// <returns>
        /// The updated clone of input immutable.
        /// </returns>
        public static T Update<T>(this T immutable, Action<T> updateAction)
            where T: Immutable<T>
        {
            var clone = immutable.CloneImmutable();
            updateAction(clone);
            return clone;
        }

        /// <summary>
        /// Use this method to update properties with setters (init, private, protected, public) returning a new instance if update was neccessary.
        /// </summary>
        /// <typeparam name="TInstance">Type of the instance.</typeparam>
        /// <typeparam name="TValue">Type of the value.</typeparam>
        /// <param name="instance">Original instance from which the new one with updated value will be created.</param>
        /// <param name="memberLamda">Member to be updated.</param>
        /// <param name="value">The new value.</param>
        /// <param name="forceNewInstance">If true, a new instance is returned even if the value is equal to the original</param>
        /// <returns></returns>
        public static TImmutable With<TImmutable, TValue>(
            this TImmutable instance,
            Expression<Func<TImmutable, TValue>> memberLamda,
            TValue value,
            bool forceNewInstance = false)
            where TImmutable : Immutable<TImmutable>
        {
            if (memberLamda.Body is not MemberExpression memberSelectorExpression)
            {
                throw new Exception("Expression must be member selector expression");
            }

            var property = memberSelectorExpression.Member as PropertyInfo;
            if (property == null)
            {
                throw new ArgumentException("Property info for member expression not found");
            }

            var originalValue = property.GetValue(instance);
            if(!forceNewInstance
                && (originalValue == null && value == null || (originalValue?.Equals(value) ?? false)))
            {
                return instance;
            }

            var newInstance = instance.CloneImmutable();
            property.SetValue(newInstance, value, null);
            return newInstance;
        }
    }
}
