using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace ExpressionTreesUsage.Extensions
{
    public static class ControllerExtensions
    {
        public static IActionResult RedirectToAction<TController>(
            this Controller controller,
            Expression<Action<TController>> redirectExpression)
            where TController : Controller
        {
            if (redirectExpression.Body is MethodCallExpression methodCallExpression)
            {
                var controllerName = typeof(TController).Name.Replace(nameof(Controller), string.Empty);
                var actionName = methodCallExpression.Method.Name;

                var arguments = methodCallExpression.Arguments;
                var routeValueDictionary = new RouteValueDictionary();

                var keys = methodCallExpression.Method
                    .GetParameters()
                    .Select(p => p.Name)
                    .ToList();

                for (var i = 0; i < arguments.Count; i++)
                {
                    var argumentExpression = (ConstantExpression)arguments[i];

                    var key = keys[i];
                    var value = argumentExpression.Value;

                    routeValueDictionary.Add(key, value);
                }

                return controller.RedirectToAction(actionName, controllerName, routeValueDictionary);
            }
            else
            {
                throw new InvalidOperationException("Expression is not valid!");
            }
        }
    }
}
