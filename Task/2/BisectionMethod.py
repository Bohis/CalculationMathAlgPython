import math,FunctionTask

"""Метод бисекции"""
a = float(input("a = "))
b = float(input("b = "))
accuracy = float(input("accuracy = "))

x = (a+b)/2.0
while abs(a-b)/(2) >= accuracy:
    if FunctionTask.Function2(a) * FunctionTask.Function2(x) < 0:
        b = x
    if FunctionTask.Function2(b) * FunctionTask.Function2(x) < 0:
        a = x
    x = (a+b)/2.0
print ("x = ", round(x,2))
print ("f(x) = ", round(FunctionTask.Function2(x),2))
