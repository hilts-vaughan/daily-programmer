import string
from collections import Counter

def get_word_score(word):
    i = 1
    total = 0
    for c in word:
        total = total + (score_map[c] * i)
        i = i + 1
    return total

def best_word_given_tiles(tiles):
    best = ('', 0)
    for entry in word_scores:
        word = entry[0]
        if can_form_word_from_tiles(tiles, word) and entry[1] > best[1]:
            best = entry
    return best

def can_form_word_from_tiles(tiles, word):
    tile_count = Counter(tiles)
    word_count = Counter(word)

    for key, tiles_needed in word_count.items():
        tile_on_hand = tile_count[key]
        if tile_on_hand < tiles_needed:
            return False
    return True

# Generate score card
letters = tuple(string.ascii_lowercase)
scores = (1,3,3,2,1,4,2,4,1,8,5,1,3,1,1,3,10,1,1,1,1,4,4,8,4,10)
score_map = zip(letters, scores)
score_map = dict((x, y) for x, y in score_map)

words = tuple(line.rstrip('\n') for line in open('dict'))
word_scores = [get_word_score(word) for word in words]
word_scores = tuple(zip(words, word_scores))

cases = ("iogsvooely", "seevurtfci", "vepredequi", "umnyeoumcp", "orhvtudmcz", "fyilnprtia")
res = [best_word_given_tiles(case) for case in cases]
print(res)
