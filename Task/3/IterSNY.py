import numpy as np
import Matrix,math

#Итерационный метод
def IterSNAY(function,x,y,accur):
    xNew = function[0](x,y)
    yNew = function[1](x,y)

    newValue = (xNew,yNew)
    if abs(xNew - x) > accur or abs(yNew - y) > accur:
        newValue = IterSNAY(function,xNew,yNew,accur)
    
    return newValue

#Решение
x0 = 1
y0 = 1

func  = (lambda x,y: 1 - math.cos(y)/2.0, lambda x,y: math.sin(x + 1) - 1.2)
accuracy = 0.0001
print("Решение СНАУ: ",IterSNAY(func,x0,y0,accuracy))
    
