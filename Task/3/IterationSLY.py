import math, Matrix
import numpy as np

#Итерационный метод решения СЛАУ
def MethodDeterminatFunc(cBase,fBase,xNumber,accur):
    xNumberNext = Matrix.MatrixMove(Matrix.Multiplication(cBase,xNumber),fBase,lambda x1, x2 : x1+x2)
    forAccuracy = Matrix.MatrixMove(xNumberNext,xNumber,lambda x1,x2:abs(x2 - x1))
    
    for j in range(0,forAccuracy.shape[0]):
        if forAccuracy[j][0] > accur:
            xNumberNext = MethodDeterminatFunc(cBase,fBase,xNumberNext,accur)
            break
        
    return xNumberNext

def Result():
    A = np.array([[0,0.317,-0.061,-0.175],
                           [0.404,0,-0.072,0.003],
                           [-0.031,-0.028,0,0.731],
                           [-0.145,0.002,1.208,0]])
    
    B = np.array([[0.484],
                          [-0.122],
                          [-0.061],
                          [0.257]])

    xBase = np.array([[0.484],
                                 [-0.122],
                                 [-0.061],
                                 [0.257]])
    accuracy = 0.01

    print("Матрица коофициентов:\n",A)
    print("Матрица свободных членов:\n",B)
    print("Начальное приближение:\n",xBase)

    result = MethodDeterminatFunc(A,B,xBase,accuracy)
    print("Решение:\n",result)
