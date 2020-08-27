import math

#Базовая функция
def Function(x):
    return x - math.sin(x) - 0.25

#Первая производная
def Derivate(x):
    return 1 - math.cos(x)

#Вторая производная
def DerivateTwo(x):
    return 1 + math.sin(x)

#Рекурсионный метод касательных
def RecursionTanget(x,accuracy):
    newX = x - Function(x)/Derivate(x)
    if abs(newX - x) > accuracy:
        return RecursionTanget(newX,accuracy)
    else:
        return newX

#Вызовы программы
print("Метод касательных Ньютона")
x = 1.5
accuracy = 0.001
y = round(RecursionTanget(float(x),accuracy),4)
print("x =",y,"f(x) =",round(Function(y),4))
