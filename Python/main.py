import numpy as np
import pandas as pd
import os
import json
import matplotlib.pyplot as plt
from PIL import Image

f = open("Data/Gazelog-2020-06-11-13-25-23/info.json") 

data = pd.read_csv("Data/Gazelog-2020-06-11-13-25-23/gazelog-2020-06-11-13-25-23.csv")
info = json.load(f)
img = Image.open("Assets/Resources/images/" + info["image"] + ".jpg")

bounds = [ 
        [ info["centerX"] - (info["sizeX"] / 2.0), info["centerX"] + (info["sizeX"] / 2.0)],
        [ info["centerY"] - (info["sizeY"] / 2.0), info["centerY"] + (info["sizeY"] / 2.0)]
        ]
bounds = [[-10,10], [-5, 5]]
N_bins = 100


plt.imshow(img, extent=[item for sublist in bounds for item in sublist])
plt.hist2d(data['x'], data['y'], bins=N_bins, normed=False, cmap='plasma', range=bounds, cmin=1)

# Plot a colorbar with label.
cb = plt.colorbar()
cb.set_label('Number of entries')

# Add title and labels to plot.
plt.title('Heatmap of where user looking at')
plt.xlabel('x axis')
plt.ylabel('y axis')

# Show the plot.
plt.show()