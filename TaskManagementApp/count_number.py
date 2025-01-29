s = input().strip()

# Сортируем цифры в порядке убывания
digits = sorted(s, reverse=True)

# Ищем первую нечётную цифру (для корректной перестановки)
odd_digit = None
for i in range(len(digits) - 1, -1, -1):
    if int(digits[i]) % 2 == 1:
        odd_digit = digits.pop(i)  # Убираем её из списка
        break

# Если нечётной цифры нет, выводим "NO"
if odd_digit is None:
    print("NO")
else:
    # Собираем наибольшее число с нечётной цифрой в конце
    result = "".join(digits) + odd_digit
    
    # Убираем ведущие нули, если они есть
    result = result.lstrip('0')
    
    # Если после удаления нулей строка стала пустой (например, ввод "0"), то выводим "NO"
    if not result:
        print("NO")
    else:
        print(result)
