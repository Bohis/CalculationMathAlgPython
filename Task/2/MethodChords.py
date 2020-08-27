import math

#Исходная функция
def Function(_x):
    return _x**3-3*_x**2+9*_x-8

#Первая производная
def DerivativeFirst(_x):
    return 3*_x**2-6*_x+9

#Вторая производная
def DerivativeSecond(_x):
    return 6*_x-6

# Данные для вычесления точности k приблежения
k = 1
i = 0
m = DerivativeFirst(2)
# ===========================================================

#Рекурсионая функция, метод хорд
# _Funs - кортеж из функции, первой производной и второй
# _a,_b - границы отрезка, содержащего корень
# _x - приблеженное значение, вычесленное аналитически
# _accur - точность вычислений
def Chords( _Funs,  _a,  _b,  _x, _accur):
    _newX = 0
    global i
    if _Funs[0](_b) * _Funs[2](_x) > 0:
        _newX = _x - ( ( _Funs[0](_x) * (b-_x) ) / ( _Funs[0](_b) - _Funs[0](_x) ) )
    else:
        _newX = _x - ( ( _Funs[0](_a) * (_x-_a) ) / ( _Funs[0](_x) - _Funs[0](_a) ) )

    if i == k:
        print("Точность приближения k=",k,": ",abs(_newX - _accur)," <= ",(abs(_Funs[0](_newX))/m))
    i+=1
    if abs(_newX - _x) > _accur:
        return Chords(_Funs,_a,_b,_newX,_accur)
    else:
        return _newX

#Вычисление конкретной функции
accuracy = 0.005
x0 = 1
a = 0.25
b = 2
xn = Chords((Function,DerivativeFirst,DerivativeSecond),a,b,x0,accuracy)
y = Function(xn)
print("x =",round(xn,3),"y(x) =",round(y,3))
    
