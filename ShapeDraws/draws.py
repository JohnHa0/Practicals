# for illustration 
import matplotlib.pyplot as plt
import numpy as np

def triangle(x, center):
    if center - 0.125 <= x <= center:
        return 8 * (x - center + 0.125)
    elif center <= x <= center + 0.125:
        return 8 * (-x + center + 0.125)
    else:
        return 0

labels = ["(EP)", "(VP)", "(P)", "(MP)", "(F)", "(MG)", "(G)", "(VG)", "(EG)"]
positions = np.arange(0.125, 1.025, 0.125)
x = np.linspace(0, 1, 1000)

for pos in positions:
    y = [triangle(xi, pos) for xi in x]
    plt.plot(x, y, color='black')

plt.xticks(positions, labels)
plt.yticks([])
plt.show()