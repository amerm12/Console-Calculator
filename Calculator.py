import math

#Function for addition
def add(a, b):
    return a + b


#Function for subtraction
def subtract(a, b):
    return a - b


#Function for multiplication
def multiply(a, b):
    return a * b


#Function for division
def divide(a, b):
    while b == 0:
        print("Denominator can not be zero! Input second number again:")
        b = float(input())
    return a / b


#Function for remainder calculation
def calculate_remainder(a, b):
    return a % b


#Function for exponentiation calculation
def calculate_exponentiation(a, b):
    exponentiation_result = 1
    while b < 0:
        print("Exponent can not be negative! Input another exponent:")
        b = int(input())
    n = 0
    while n < b:
        exponentiation_result = exponentiation_result * a
        n += 1
    return exponentiation_result


#Function for square root calculation
def calculate_square_root(a):
    if a < 0:
        print("There is no square root of negative number!")
        exit()
    else:
        return math.sqrt(a)


#Function for number input and checking validity
def check_float():
    while True:
        try:
            a = float(input())
            return a
        except ValueError:
            print("Invalid input! Input must be a number!")


#Function for operation input and checking validity
def check_operation():
    while True:
        a = input()
        if a == "+" or a == "-" or a == "*" or a == "/" or a == "%" or a == "^" or a == "s" or a == "M" or a == "m":
            return a
        elif a == "q" or a == "Q":
            exit()
        else:
            print("Invalid input! Input must be operation!")


#Function for second input and checking validity 
def check_second_input():
    while True:
        second_input = input()

        if second_input.isdigit() == True or second_input.lstrip('-').isdigit() == True:
            return second_input

        elif isinstance(second_input, str):
            if second_input == "+" or second_input == "-" or second_input == "*" or second_input == "/" \
                    or second_input == "%" or second_input == "^" or second_input == "s" \
                    or second_input == "M" or second_input == "m" or second_input == "P" or second_input == "p":
                return second_input
            elif second_input == "q" or second_input == "Q":
                exit()
            elif (second_input[0] == 'R' or second_input[0] == 'r') and second_input[1].isdigit():
                return second_input
        else:
            print("Invalid input. Input must be number or operation!")


first_while = True
second_while = True
second_operation_while = True
switch_while = True
stored_numbers = []

#Printing calculator options
print("        >>> Calculator <<<")
print("-----------------------------------")
print("Calculator can:" +
      "\n \t Add (+) " +
      "\n \t Subtract (-)" +
      "\n \t Multiply (*) " +
      "\n \t Divide (/)" +
      "\n \t Calculate Remainder (%)" +
      "\n \t Calculate Exponent (^)" +
      "\n \t Calculate Square Root (s)" +
      "\n \t Start calculation (=)" +
      "\n \t Save last input (M)" +
      "\n \t List all saved numbers (P)" +
      "\n \t Retrieve and continue with number from the list (Rn - where n is index of number on the list)" +
      "\n \t Quit program (q)")
print("-----------------------------------")

first_number = check_float()
#Main loop for calculator operations
while first_while == True:
    second_while = True
    operation = check_operation()

    #Check if operations is to save the last input to the list
    if operation == "M" or operation == "m":
        stored_numbers.append(first_number)
        print(first_number, "<- is added to the list!")
        operation = check_operation()

    #Loop for the second input and calculation
    while second_while == True:

        second_operation_while = True
        switch_while = True

        #Check if the operation is for calculating square root
        if operation == "s":
            second_number = 0
        else:
            second_number = check_float()

        #Checking operation 
        if operation == "+":
            result = add(first_number, second_number)
            first_number = result
            while switch_while == True:
                g = input()
                if g == "=" or g == "":
                    print(result)
                    switch_while = False
                elif g.upper() == "M":
                    stored_numbers.append(second_number)
                    print(second_number, "<- is added to the list!")
                    switch_while = True
                else:
                    print("Invalid input! Input must be equals/enter or M")

        elif operation == "-":
            result = subtract(first_number, second_number)
            first_number = result
            while switch_while == True:
                g = input()
                if g == "=" or g == "":
                    print(result)
                    switch_while = False
                elif g.upper() == "M":
                    stored_numbers.append(second_number)
                    print(second_number, "<- is added to the list!")
                    switch_while = True
                else:
                    print("Invalid input! Input must be equals/enter or M")

        elif operation == "*":
            result = multiply(first_number, second_number)
            first_number = result
            while switch_while == True:
                g = input()
                if g == "=" or g == "":
                    print(result)
                    switch_while = False
                elif g.upper() == "M":
                    stored_numbers.append(second_number)
                    print(second_number, "<- is added to the list!")
                    switch_while = True
                else:
                    print("Invalid input! Input must be equals/enter or M")

        elif operation == "/":
            result = divide(first_number, second_number)
            first_number = result
            while switch_while == True:
                g = input()
                if g == "=" or g == "":
                    print(result)
                    switch_while = False
                elif g.upper() == "M":
                    stored_numbers.append(second_number)
                    print(second_number, "<- is added to the list!")
                    switch_while = True
                else:
                    print("Invalid input! Input must be equals/enter or M")

        elif operation == "%":
            result = calculate_remainder(first_number, second_number)
            first_number = result
            while switch_while == True:
                g = input()
                if g == "=" or g == "":
                    print(result)
                    switch_while = False
                elif g.upper() == "M":
                    stored_numbers.append(second_number)
                    print(second_number, "<- is added to the list!")
                    switch_while = True
                else:
                    print("Invalid input! Input must be equals/enter or M")

        elif operation == "^":
            result = calculate_exponentiation(first_number, second_number)
            first_number = result
            while switch_while == True:
                g = input()
                if g == "=" or g == "":
                    print(result)
                    switch_while = False
                elif g.upper() == "M":
                    stored_numbers.append(second_number)
                    print(second_number, "<- is added to the list!")
                    switch_while = True
                else:
                    print("Invalid input! Input must be equals/enter or M")

        elif operation == "s":
            result = calculate_square_root(first_number)
            first_number = result
            while switch_while == True:
                g = input()
                if g == "=" or g == "":
                    print(result)
                    switch_while = False
                elif g.upper() == "M":
                    stored_numbers.append(second_number)
                    print(second_number, "<- is added to the list!")
                    switch_while = True
                else:
                    print("Invalid input! Input must be equals/enter or M")

        else:
            print("Invalid input!")

        while second_operation_while == True:

            second_operation = check_second_input()

            if second_operation.isdigit() == True or second_operation.lstrip('-').isdigit() == True:
                first_while = True
                second_while = False
                first_number = float(second_operation)
                second_operation_while = False

            #Check if the operation is for retrieving number from the list
            elif (second_operation[0] == 'R' or second_operation[0] == 'r') and second_operation[1].isdigit():
                r_num = int(second_operation[1])
                if r_num <= len(stored_numbers) and r_num > 0:
                    first_number = stored_numbers[r_num - 1]
                    print("You accessed number: ", first_number)
                    second_operation_while = True
                elif r_num > len(stored_numbers):
                    print("Result does not exist at location!")
                    second_operation_while = True
                elif r_num <= 0:
                    print("Result does not exist at location!")
                    second_operation_while = True

            elif second_operation.isdigit() == False or second_operation.lstrip('-').isdigit() == False:
                if second_operation == "M" or second_operation == "m":
                    stored_numbers.append(first_number)
                    print(first_number, "<- is added to the list!")
                    second_operation_while = True
                #Check if the operation is for listing all saved numbers
                elif second_operation == "P" or second_operation == "p":
                    print("----------")
                    print("List of saved numbers: ")
                    for i, x in enumerate(stored_numbers):
                        print("[", i + 1, "]", stored_numbers[i])
                    print("----------")
                    second_operation_while = True
                else:
                    first_while = False
                    second_while = True
                    operation = str(second_operation)
                    second_operation_while = False
