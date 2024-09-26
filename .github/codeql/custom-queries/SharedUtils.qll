import csharp

class AspNetController extends Class {
  AspNetController() {
    this.getABaseType+().hasFullyQualifiedName("Microsoft.AspNetCore.Mvc", "ControllerBase")
  }
}

class ControllerMethod extends Method {
  ControllerMethod() { this.getDeclaringType() instanceof AspNetController }
}

class ControllerParameter extends Parameter {
  ControllerParameter() { exists(ControllerMethod m | this = m.getParameter(_)) }
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

predicate hasFromRouteAttribute(Parameter p) {
  exists(Attribute a |
    a.getType().getName() = "FromRouteAttribute" and
    a.getTarget() = p
  )
}

predicate hasFromQueryAttribute(Parameter p) {
  exists(Attribute a |
    a.getType().getName() = "FromQueryAttribute" and
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
