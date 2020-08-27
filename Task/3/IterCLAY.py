import math, Matrix
import numpy as np

#Вычисления массива функций
def DeterminatFunc(baseFunc,baseValue):
    newValue = np.zeros((baseFunc.shape[0],baseFunc.shape[1]))

    for i in range(0,newValue.shape[0]):
        for j in range(0,newValue.shape[1]):
            newValue[i][j] = baseFunc[i][j](baseValue[0],baseValue[1])

    return Matrix.Determinat(newValue)

#Метод задания матриц для задания 3.2
def Decision1(baseX, accur):
    ikobi = np.array([[lambda x,y: 2*x,     lambda x,y:  2*y],
                              [lambda x,y: 3*x**2, lambda x,y:  -1   ]])

    delta1 = np.array([[lambda x,y: x**2 + y**2 - 1, lambda x,y:  2*y],
                                [lambda x,y: x**3 - y,          lambda x,y:  -1   ]])

    delta2 = np.array([[lambda x,y: 2*x,     lambda x,y:  x**2 + y**2 - 1],
                                 [lambda x,y: 3*x**2, lambda x,y:  x**3 - y  ]])

    return RecursionDesicion(ikobi,delta1,delta2,baseX,accur)

#Метод задания матриц для задания 3.3
def Decision2(baseX, accur):
    ikobi = np.array([[lambda x,y: y/(math.cos(x*y+0.4)**2) -2*x,     lambda x,y:  x/(math.cos(x*y+0.4)**2)],
                              [lambda x,y: 1.2*x, lambda x,y:  4*y  ]])

    delta1 = np.array([[lambda x,y: math.tan(x*y+0.4)-x*x,     lambda x,y:  x/(math.cos(x*y+0.4)**2)],
                              [lambda x,y: 0.6*x*x+2*y*y-1, lambda x,y:  4*y  ]])

    delta2 = np.array([[lambda x,y: y/(math.cos(x*y+0.4)**2) -2*x,     lambda x,y: math.tan(x*y+0.4)-x*x],
                              [lambda x,y: 1.2*x, lambda x,y:  0.6*x*x+2*y*y-1 ]])

    return RecursionDesicion(ikobi,delta1,delta2,baseX,accur)

#Рекурсионный метод итерационнго вычисления
def RecursionDesicion(ikobi,delta1,delta2,baseX,accur):
    
    ikobiD = DeterminatFunc(ikobi,baseX)
    delta1D = DeterminatFunc(delta1,baseX)
    delta2D = DeterminatFunc(delta2,baseX)

    newX = (baseX[0]-delta1D/ikobiD,baseX[1]-delta2D/ikobiD)

    if abs(newX[0] - baseX[0]) > accur or abs(newX[1] - baseX[1]) > accur:
        newX = RecursionDesicion(ikobi,delta1,delta2,newX,accur)
    return newX

x = 1
y = 1

accuracy = 0.0001

print("Решения",Decision1((1,1),accuracy))

x = 1
y = 1

accuracy = 0.001

print("Решения",Decision2((1,1),accuracy))
