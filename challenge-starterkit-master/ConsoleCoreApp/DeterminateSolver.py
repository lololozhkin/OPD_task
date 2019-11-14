def m(a):
    n = len(a)
    if n == 1:
        return a[0][0]
    ans = 0
    for i in range(n):
        c = []
        for k in range(1, n):
            b = []
            for j in range(n):
                if i != j:
                    b.append(a[k][j])
            c.append(b)
        if (i % 2 == 0):
            ans += a[0][i] * m(c)
        else:
            ans -= a[0][i] * m(c)
    return ans


def get_answer(s):
    s = list(map(int, s.replace(' \\\\ ', ' & ').split(' & ')))
    matrix = [[] for _ in range(int(len(s) ** 0.5 + 0.00001))]
    p = 0
    for i in range(int(len(s) ** 0.5)):
        for j in range(int(len(s) ** 0.5)):
            matrix[i].append(s[p])
            p += 1
    a = str(m(matrix))
    return a
