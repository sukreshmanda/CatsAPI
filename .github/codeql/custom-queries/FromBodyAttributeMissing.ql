/**
 * @name Enforce [FromBody] attribute for non-primitive parameters in controller methods with specific HTTP method attributes
 * @description This query checks if non-primitive parameters in ASP.NET Core controller methods, which have specific route and HTTP method attributes, are decorated with the [FromBody] attribute.
 * @kind problem
 * @problem.severity error
 * @precision high
 * @id csharp/no-from-body
 * @tags style
 */

import SharedUtils

from ControllerMethod m, ControllerParameter p
where
  p = m.getParameter(_) and
  hasHttpRouteAttribute(m) and
  not isPrimitiveType(p.getType()) and
  not hasFromBodyAttribute(p)
select p,
  "The parameter '" + p.getName() + "[" + p.getType() + "]" + "' in the method '" + m.getName() +
    "': " + m.getDeclaringType()
