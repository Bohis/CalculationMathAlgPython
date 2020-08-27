import numpy as np
import math as mt

# Интерполяционный многочлен Лангранжа
def Langrange(arrayX,arrayY,arrayNewX):
    arrayNew = np.zeros((arrayX.shape[0],arrayX.shape[0]))
    arrayD = np.zeros((arrayX.shape[0]))
    arrayL = np.zeros((arrayX.shape[0]))
    arrayNewY = np.zeros((arrayNewX.shape[0]))

    for k in range(0,arrayNewX.shape[0]):
        for i in range(0,arrayNew.shape[1]):
            arrayD[i] = 1
            tempD = 1

            for j in range(0,arrayNew.shape[1]):

                if j == i:
                    arrayNew[i][j] = 0
                else:
                    arrayNew[i][j] = arrayX[i]-arrayX[j]
                    arrayD[i] *= arrayNew[i][j]
                    tempD *= arrayNewX[k]-arrayX[j]

            arrayL[i] = arrayY[i] / arrayD[i]
            arrayNewY[k] += arrayL[i]*tempD
    return arrayNewY

# Интерполяционнный многочлен Ньютона второго порядка
def NewtonMethodTwo(arrayX,arrayY,valueX):
    h = arrayX[1]-arrayX[0]
    temp = arrayY[arrayY.shape[0]-1]
    q = (valueX - arrayX[arrayX.shape[0]-1])/h
    difTab = np.zeros((arrayY.shape[0],arrayY.shape[0]))

    for i in range(0,arrayY.shape[0]):
        difTab[i][0] = arrayY[i]

    for j in range(1,difTab.shape[1]):
        for i in range(0,difTab.shape[0]-j):
            difTab[i][j] = difTab[i+1][j-1]-difTab[i][j-1]

    def factorial (_n):
        if _n == 1:
            return 1
        else:
            return _n * factorial(_n-1)
    
    def coof  (_q,_n):
        result = 1.0/factorial(_n)
        for i in range(1,_n+1):
            result *= _q + i - 1

        return result

    i = difTab.shape[0] - 2
    j = 1
    while i >= 0:
        temp += coof(q,j) * difTab[i][j]
        j+=1
        i-=1

    return temp

# Интерполяционнный многочлен Ньютона первого порядка
def NewtonMethodFirst(arrayX,arrayY,valueX):
    h = arrayX[1]-arrayX[0]
    temp = arrayY[0]
    q = (valueX - arrayX[0])/h
    difTab = np.zeros((arrayY.shape[0],arrayY.shape[0]))

    for i in range(0,arrayY.shape[0]):
        difTab[i][0] = arrayY[i]

    for j in range(1,difTab.shape[1]):
        for i in range(0,difTab.shape[0]-j):
            difTab[i][j] = difTab[i+1][j-1]-difTab[i][j-1]

    def factorial (_n):
        if _n == 1:
            return 1
        else:
            return _n * factorial(_n-1)
    
    def coof  (_q,_n):
        result = 1.0/factorial(_n)
        for i in range(1,_n+1):
            result *= _q - i + 1
        return result
    
    j = 1
    for i in range(0,difTab.shape[0]-1): 
        temp += coof(q,j) * difTab[0][j]
        j+=1

    return temp


if __name__ == "__main__":
    #4.1
   arrayY = np.array([1.172,1.179,1.182,1.186,1.189])
   arrayX = np.array([1.62,1.64,1.65,1.67,1.68])
   arrayNewX = np.array([1.63])

   resultArray = Langrange(arrayX,arrayY,arrayNewX)
   print(resultArray)
   
   resultArray = NewtonMethodTwo(arrayX,arrayY,arrayNewX[0])
   print(resultArray)
#4.2
   arrayX = np.array([0,1.4,2.6,4])
   arrayY = np.array([1,0.180,0.043,0.006])
   arrayNewX = np.array([1.7])
   
   resultArray = Langrange(arrayX,arrayY,arrayNewX)
   print(resultArray)
   
#4.3.1
   arrayX = np.array([1.2,1.25,1.3,1.35,1.4,1.45,1.5,1.55,1.6,1.65])
   arrayY = np.array([3.32,3.491,3.669,3.857,4.055,4.263,4.482,4.712,4.953,5.203])
   arrayNewX = np.array([1.22])
   
   resultArray = NewtonMethodTwo(arrayX,arrayY,arrayNewX[0])
   print(resultArray)

   resultArray = NewtonMethodFirst(arrayX,arrayY,arrayNewX[0])
   print(resultArray)

