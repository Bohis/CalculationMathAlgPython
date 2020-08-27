import math,FunctionTask

"""Метод бисекции"""
a = float(input("a = "))
b = float(input("b = "))
accuracy = float(input("accuracy = "))

x = (a+b)/2.0
while abs(a-b)/(2.0) >= accuracy:
    if FunctionTask.Function4(a) * FunctionTask.Function4(x) < 0:
        b = x
    if FunctionTask.Function4(b) * FunctionTask.Function4(x) < 0:
        a = x
    x = (a+b)/2.0
print ("x = ", round(x,4))
print ("f(x) = ", round(FunctionTask.Function4(x),4))
