import FunctionTask
import math, sys

a = float(input("a = "))
b = float(input("b = "))
step = float(input("step = "))
"""[a,b] корня функции, step - щаг хода"""
print ("Табличный метод отделения корней")
while a <= b:
    print ("|x = " , round(a,3), "|f(x) = ",round(FunctionTask.Function2(a),3),"|")
    a+=step
    
        
    
    



