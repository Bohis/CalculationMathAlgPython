import math, Matrix,IterationSLY
import numpy as np

#Решение СЛАУ методом Зейделя
def Zeildel(aBase,bBase,xNumber,accur):
    xNumberNext = np.zeros((xNumber.shape[0],xNumber.shape[1]))

    for i in range(0,xNumberNext.shape[0]):
        xNumberNext[i][0] = xNumber[i][0]
    
    for i in range(0,aBase.shape[0]):
        temp = 0
        for j in range(0,aBase.shape[1]):
            temp+=xNumberNext[j][0] * aBase[i][j]
        xNumberNext[i][0] = temp

    forAccuracy = Matrix.MatrixMove(xNumberNext,xNumber,lambda x1,x2:abs(x2 - x1))

    for j in range(0,forAccuracy.shape[0]):
        if forAccuracy[j][0] > accur:
            xNumberNext = IterationSLY.MethodDeterminatFunc(aBase,bBase,xNumberNext,accur)
            break

    return xNumberNext


A = np.array([[0,0.405,-0.310],
                       [-0.667,0,-0.167],
                       [-0.125,-0.083,0]])

B = np.array([[0.667],
                       [0.667],
                       [-0.542]])

xBase = np.array([[0.667],
                       [0.667],
                       [-0.542]])

accuracy = 0.001
print("Матрица коофициентов:\n",A)
print("Матрица свободных членов:\n",B)
print("Начальное приближение:\n",xBase)

result = Zeildel(A,B,xBase,accuracy)
print("Решение:\n",result)
