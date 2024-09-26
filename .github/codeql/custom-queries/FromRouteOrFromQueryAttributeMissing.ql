/**
 * @name Enforce [FromQuery] or [FromRoute] attribute for primitive parameters in controller methods with specific HTTP method attributes
 * @description This query checks if primitive parameters in ASP.NET Core controller methods, which have specific route and HTTP method attributes, are decorated with the [FromQuery] or [FromRoute] attribute.
 * @kind problem
 * @problem.severity error
 * @precision high
 * @id csharp/no-from-query-or-route-attribute
 * @tags style
 */

import SharedUtils

from ControllerMethod m, ControllerParameter p
where
  p = m.getParameter(_) and
  m.getNumberOfParameters() > 1 and
  hasHttpRouteAttribute(m) and
  isPrimitiveType(p.getType()) and
  not (hasFromRouteAttribute(p) or hasFromQueryAttribute(p))
select p,
  "The parameter '" + p.getName() + "[" + p.getType() + "]" + "' in the method '" + m.getName() +
    "': " + m.getDeclaringType()
