import math

#Базовая функция
def Function(_x):
    return _x**3+2*_x**2+2

#Модифицированая функция для итерации
def IterModFunc(_x):
    return _x - ( Function( _x ) ) / (3*_x**2+4*_x)

#Итерациный метод
def IterRecursion(_func,_x,_accur):
    _newX = IterModFunc(_x)
    if abs(_newX - _x) > _accur:
        return IterRecursion(_func,_newX,_accur)
    else:
        return _newX

#Решение задание
x = -2
accuracy = 0.005
newX = IterRecursion(Function,x,accuracy)

print("x =",round( newX,4),"f(x) =",round(Function(newX),4))
    
