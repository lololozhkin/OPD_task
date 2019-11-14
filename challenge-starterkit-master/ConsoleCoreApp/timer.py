import time
from ComplexSolver import complex_solver

if __name__ == '__main__':
    while True:
        time.sleep(2)
        answer = ''
        with open('in.txt', 'r', encoding='utf-8') as data_file:
            data = data_file.readlines()
            if data:
                answer = complex_solver(data[0][:-1])
        with open('in.txt', 'w', encoding='utf-8') as f:
            pass
        with open('out.txt', 'w', encoding='utf-8') as ans_file:
            ans_file.write(answer)
