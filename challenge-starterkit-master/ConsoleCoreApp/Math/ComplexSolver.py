def complex_solver(s):
    s = s.replace(" ", "")

    s = s.replace("i", "*i")
    s = s.replace("-*", "-")
    s = s.replace("+*", "+")
    s = s.replace("**", "*")
    s = s.replace("(*", "(")
    if (s[0] == '*'):
        s = s[1:]

    s = s.replace("(", "*(")
    s = s.replace("-*", "-")
    s = s.replace("+*", "+")
    s = s.replace("**", "*")
    s = s.replace("(*", "(")
    if (s[0] == '*'):
        s = s[1:]

    s = s.replace("i", "i*")
    s = s.replace("*-", "-")
    s = s.replace("*+", "+")
    s = s.replace("**", "*")
    s = s.replace("*)", ")")
    if (s[-1] == '*'):
        s = s[:-1]

    s = s.replace(")", ")*")
    s = s.replace("*-", "-")
    s = s.replace("*+", "+")
    s = s.replace("**", "*")
    s = s.replace("*)", ")")
    if (s[-1] == '*'):
        s = s[:-1]

    s = "(" + s + ")"
    s = s.replace("i", "j")
    
    # print(s)

    digs = "1234567890"

    startdig = 0
    enddig = 0
    i = 1
    while i < len(s):
        if s[i] == 'j':
            s = str(s[:i]) + "(0+1j)" + str(s[i + 1:])
            i += 5
        else:
            if s[i] in digs and s[i - 1] not in digs:
                startdig = i
            if s[i] not in digs and s[i - 1] in digs:
                enddig = i - 1

            if enddig > 0:
                s = str(s[:startdig]) + "(" + str(s[startdig:enddig + 1]) + "+0j)" + str(s[enddig + 1:])
                i = enddig + 6
                startdig = 0
                enddig = 0

        i += 1

    # print(s)

    # print(eval(s))
    num = eval(s)
    real = num.real
    imag = num.imag
    # ans = str(eval(s))
    # ans = ans.replace("j", "i")
    # ans = ans.replace("(", "")
    # ans = ans.replace(")", "")
    # print(ans)
    
    ans = ""
    if (abs(real) < 1e-9 and abs(imag) < 1e-9):
        ans = "0"
    elif (abs(real) < 1e-9):
        if (abs(imag - 1) < 1e-9):
            ans = "i"
        elif (abs(imag + 1) < 1e-9):
            ans = "-i"
        else:
            ans = str(int(imag)) + "i"
    elif (abs(imag) < 1e-9):
        ans = str(int(real))
    elif (imag > 1e-9):
        if (abs(imag - 1) < 1e-9):
            ans = str(int(real)) + "+i"
        else:
            ans = str(int(real)) + "+" + str(int(imag)) + "i"
    else:
        if (abs(imag + 1) < 1e-9):
            ans = str(int(real)) + "-i"
        else:
            ans = str(int(real)) + str(int(imag)) + "i"

    return ans
