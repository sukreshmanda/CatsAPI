/**
 * @name Enforce [FromBody] attribute for non-primitive parameters in controller methods with specific HTTP method attributes
 * @description This query checks if non-primitive parameters in ASP.NET Core controller methods, which have specific route and HTTP method attributes, are decorated with the [FromBody] attribute.
 * @kind problem
 * @problem.severity error
 * @precision high
 * @id csharp/no-from-body
 * @tags style
 */

 import csharp

 class AspNetController extends Class {
   AspNetController() {
     this.getABaseType+().hasFullyQualifiedName("Microsoft.AspNetCore.Mvc", "ControllerBase")
   }
 }
 
 class ControllerMethod extends Method {
   ControllerMethod() {
     this.getDeclaringType() instanceof AspNetController
   }
 }
 
 class ControllerParameter extends Parameter {
   ControllerParameter() {
     exists(ControllerMethod m | this = m.getParameter(_))
   }
 }
 
 predicate hasHttpRouteAttribute(Method m) {
  exists(Attribute a |
    (
      a.getType().getName() = "RouteAttribute" or
      a.getType().getName() = "HttpPostAttribute" or
      a.getType().getName() = "HttpPutAttribute" or
      a.getType().getName() = "HttpDeleteAttribute" or
      a.getType().getName() = "HttpGetAttribute"
    ) and
    a.getTarget() = m
  )
}

predicate hasFromBodyAttribute(Parameter p) {
  exists(Attribute a |
    a.getType().getName() = "FromBodyAttribute" and
    a.getTarget() = p
  )
}

 
 predicate isPrimitiveType(Type t) {
  t instanceof IntType or
  t instanceof LongType or
  t instanceof BoolType or
  t instanceof StringType or
  t instanceof DoubleType 
 }
 
 from ControllerMethod m, ControllerParameter p
 where
   p = m.getParameter(_) and
   m.getNumberOfParameters() > 1 and
   hasHttpRouteAttribute(m) and                
   not isPrimitiveType(p.getType()) and        
   not hasFromBodyAttribute(p)                
 select p, "The parameter '" + p.getName()+ "["+p.getType()+"]" + "' in the method '" + m.getName() + ": "+m.getDeclaringType() +"Params count: "+m.getNumberOfParameters()
