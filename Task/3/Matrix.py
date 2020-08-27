import numpy as np

#Умножение матриц
def Multiplication(A,B):
    sizeA = A.shape
    sizeB = B.shape

    if sizeA[1] != sizeB[0]:
        return 0

    C = np.zeros((sizeA[0],sizeB[1]))
    for i in range(0,sizeA[0]):
        for j in range(0,sizeB[1]):
            for k in range(0,sizeA[1]):
                C[ i ] [  j ] += A[i][k]*B[k][j]
    return C

#Действие с элементами матриц, задаваймое в виде лямда-выражения
def MatrixMove(aBase,bBase,moveFunc):
    cNew = np.zeros((aBase.shape[0],aBase.shape[1]))

    for i in range(0,cNew.shape[0]):
        for j in range(0,cNew.shape[1]):
            cNew[i][j] = moveFunc(aBase[i][j],bBase[i][j])

    return cNew

#Определитель
def Determinat(array):
    if array.shape[0] == 1:
        return array[0][0]

    n = array.shape[0]
    nStr = 0
    nStl = 0
    iMod = 0
    jMod = 0
    result = 0
    arrayMod = np.zeros((n-1,n-1))
    
    for g in range(0,n):
        for j in range(0,n):
            for i in range(0,n):
                if i!=nStr and j !=nStl:
                    arrayMod[jMod][iMod] = array[i][j]
                    jMod+=1
                    if jMod == n - 1:
                        jMod = 0
                        iMod +=1
        result+=(-1)**nStl * array[nStr][nStl] * Determinat(arrayMod)
        iMod = 0
        jMod = 0
        arrayMod = np.zeros((n-1,n-1))
        nStl+=1
    return result

#Метод крамера
def Cramer(array,freeMember):
    result = np.zeros((array.shape[0]))
    detA = Determinat(array)
    for i in range(0,result.shape[0]):
        result[i] = Determinat(ExchangeColInMatrix(i,array,freeMember))/detA
    return result

#Обмен колонками в матрице
def ExchangeColInMatrix(jBase,arrayBase,arrayNewColl):
    arrayNew = np.zeros((arrayBase.shape[0],arrayBase.shape[1]))
    for i in range(0,arrayBase.shape[0]):
        for j in range(arrayBase.shape[1]):
            if j == jBase:
                arrayNew[i][j]=arrayNewColl[i]
            else:
                arrayNew[i][j]=arrayBase[i][j]

    return arrayNew

#Транспонирование матрицы
def Transpose(matrix):
    newMatrix = np.zeros((matrix.shape[1],matrix.shape[0]))
    for i in range(0,matrix.shape[0]):
        for j in range(0,matrix.shape[1]):
            newMatrix[i][j] = matrix[j][i]

    return newMatrix

#Обратная матрица
def InverseMatrix(baseMatrix):
    newMatrix = np.zeros((baseMatrix.shape[0],baseMatrix.shape[1]))
    for i in range(0,newMatrix.shape[0]):
        for j in range(0,newMatrix.shape[1]):
            temp = np.zeros((baseMatrix.shape[0]-1,baseMatrix.shape[1]-1))
            iSpec = 0
            jSpec = 0
            for it in range(0,newMatrix.shape[0]):
                for jt in range(0,newMatrix.shape[1]):
                    if i!=it and j !=jt:
                        temp[iSpec][jSpec] = baseMatrix[it][jt]
                        jSpec+=1
                    if(jSpec == temp.shape[1]):
                        jSpec = 0
                        iSpec+=1
            newMatrix[i][j] = (-1)**(i+j)*Determinat(temp)
    newMatrix = Transpose(newMatrix)

    inverseDeterminate = 1.0/Determinat(baseMatrix)

    for i in range(0,newMatrix.shape[0]):
        for j in range(0,newMatrix.shape[1]):
            newMatrix[i][j] = newMatrix[i][j]*inverseDeterminate

    return newMatrix







                        













    

