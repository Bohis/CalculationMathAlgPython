import math

#Базовая функция
def Function(_x):
    return math.log(_x,math.e) + (_x + 1) ** 3

#Модифицированая функция для итерации
def IterModFunc(_x):
    return _x - ( Function( _x ) ) / ( ( 1 / _x ) + 3 * ( x + 1 ) ** 2)

#Итерациный метод
def IterRecursion(_func,_x,_accur):
    _newX = IterModFunc(_x)
    if abs(_newX - _x) > _accur:
        return IterRecursion(_func,_newX,_accur)
    else:
        return _newX

#Решение задание
x = 0.1
accuracy = 0.001
newX = IterRecursion(Function,x,accuracy)

print("x =",round( newX,4),"f(x) =",round(Function(newX),4))
    
