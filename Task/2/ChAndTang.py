import math

#Базовая функция
def Function(_x):
    return 2*_x**3-3*_x**2-12*_x-5

#Первая производная
def DerivateFirst(_x):
    return 6*_x**2 - 6*_x - 12

#Вторая производная
def DerivateSecond(_x):
    return 12*_x - 6

#Комбинированый метод касательных и хорд
# _Funs - кортеж из функции, первой производной и второй
# _a,_b - границы отрезка, содержащего корень
# _accur - точность вычислений
def ChAndTangMethod(_Func,_a,_b,_accur):
    _newA = 0
    _newB = 0
    _x = (_a  + _b) / 2.0
    if _Func[1](_x) * _Func[2](_x) < 0:
        _newA = _a - _Func[0](_a) / _Func[1](_a)
        _newB = _b - (_Func[0](_b) * (_b - _a) ) / (_Func[0](_b) - _Func[0](_a) )
    else:
        _newA = _a - (_Func[0](_a) * (_b - _a) ) / (_Func[0](_b) - _Func[0](_a) )
        _newB = _b - _Func[0](_b) / _Func[1](_b) 

    if abs(_newA - _newB) > _accur:
        return ChAndTangMethod(_Func,_newA,_newB,_accur)
    else:
        return (_newA  + _newB) / 2.0 

#Работа приложения
a = -1
b = 1.9
accuraty = 0.0005

x = ChAndTangMethod((Function,DerivateFirst,DerivateSecond),a,b,accuraty)
y = Function(x)

print("x =",round( x,5),"y(x) =",round(y,5))
    
