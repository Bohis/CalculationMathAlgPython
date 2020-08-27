import numpy as np
import math,Matrix

#Интерполяция линейная
def interpol(): 
    x = np.array([[1,1.62,2.62,4.25,6.68],[1,1.64,2.68,4.41,7.23],[1,1.65,2.272,4.49,7.41],[1,1.67,2.78,4.65,7.77],[1,1.68,2.82,4.74,7.96]])
    print(Matrix.InverseMatrix(x),"\n")
    print(Matrix.Multiplication(Matrix.InverseMatrix(x),x),"\n")
    y = np.array([[1.172],[1.179],[1.182],[1.186],[1.189]])
    print(Matrix.Multiplication(Matrix.InverseMatrix(x),y))

    for i in Matrix.Multiplication(Matrix.InverseMatrix(x),y):
        print(i,"  ")
    
    print(Matrix.Multiplication(x,Matrix.Multiplication(Matrix.InverseMatrix(x),y)),"\n")

interpol()

