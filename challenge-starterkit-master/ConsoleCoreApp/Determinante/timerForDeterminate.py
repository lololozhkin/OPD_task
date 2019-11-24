import time
from DeterminateSolver import get_answer

if __name__ == '__main__':
    while True:
        time.sleep(2)
        answer = ''
        with open('in1.txt', 'r', encoding='utf-8') as data_file:
            data = data_file.readlines()
            if data:
                # answer = complex_solver(data[0][:-1])
                answer = get_answer(str(data[0][:]))
            else:
                continue

        with open('in1.txt', 'w', encoding='utf-8') as f:
            pass
        with open('out1.txt', 'w', encoding='utf-8') as ans_file:
            ans_file.write(answer)