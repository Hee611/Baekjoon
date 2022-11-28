a = list(map(int, input().split(" ")))

for i in range(len(a)):
    a[i] *= a[i]
print(sum(a)%10)