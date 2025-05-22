import pygame
import math
import random
from pygame import mixer

pygame.init()

screen = pygame.display.set_mode((800, 600))
background = pygame.image.load('background.jpg')

# Background Sound
mixer.music.load('background.wav')
mixer.music.play(-1)

# Title and icon
pygame.display.set_caption("Space Invaders")
icon = pygame.image.load('ufo.png')
pygame.display.set_icon(icon)

# Player
playerImg = pygame.transform.scale(pygame.image.load('player.png'), (50, 50))
playerX = 370
playerY = 480
playerX_change = 0

# Enemy
enemyImg = []
enemyX = []
enemyY = []
enemyX_change = []
enemyY_change = []
num_of_enemies = 6

for i in range(num_of_enemies):
    enemyImg.append(pygame.transform.scale(pygame.image.load('enemy.png'), (50, 50)))
    enemyX.append(random.randint(0, 735))
    enemyY.append(random.randint(50, 150))
    enemyX_change.append(0.3)
    enemyY_change.append(40)

# Boss
bossImg = pygame.transform.scale(pygame.image.load('enemy3.png'), (80, 80))
bossX = random.randint(0, 720)
bossY = 100
bossX_change = 0.3
boss_life = 15
boss_active = False

# Bullet
bulletImg = pygame.transform.scale(pygame.image.load('bullet.png'), (10, 30))
bulletX = 0
bulletY = 480
bulletY_change = 10
bullet_state = "ready"

# Score
score_value = 0
score_color = (0, 255, 0)
font = pygame.font.Font('freesansbold.ttf', 32)
textX = 10
textY = 10
label_text = "Score"

# Game Over text
over_font = pygame.font.Font('freesansbold.ttf', 64)

def show_label(x, y, label, value, color):
    text = font.render(f"{label} : {str(value)}", True, color)
    screen.blit(text, (x, y))

def game_over_text():
    over_text = over_font.render("GAME OVER", True, (255, 0, 0))
    screen.blit(over_text, (200, 250))

def you_win_text():
    win_text = over_font.render("YOU WIN!", True, (255, 255, 0))
    screen.blit(win_text, (200, 250))

def player(x, y):
    screen.blit(playerImg, (x, y))

def enemy(x, y, i):
    screen.blit(enemyImg[i], (x, y))

def fire_bullet(x, y):
    global bullet_state
    bullet_state = "fire"
    screen.blit(bulletImg, (x + 16, y + 10))

def isCollision(x1, y1, x2, y2):
    distance = math.hypot(x1 - x2, y1 - y2)
    return distance < 27

def show_start_screen():
    ufo_image = pygame.transform.scale(pygame.image.load('ufo.png'), (40, 40))
    ufos = [(random.randint(0, 760), random.randint(0, 560)) for _ in range(80)]
    title_font = pygame.font.Font('freesansbold.ttf', 64)
    button_font = pygame.font.Font('freesansbold.ttf', 32)
    waiting = True
    while waiting:
        screen.blit(background, (0, 0))
        for (x, y) in ufos:
            screen.blit(ufo_image, (x, y))
        title_text = title_font.render("SPACE INVADERS", True, (0, 255, 0))
        screen.blit(title_text, (170, 150))
        button_text = button_font.render("CLICK PARA COMENZAR", True, (255, 255, 255))
        button_rect = button_text.get_rect(center=(400, 350))
        pygame.draw.rect(screen, (0, 100, 0), button_rect.inflate(20, 20))
        screen.blit(button_text, button_rect)
        pygame.display.update()
        for event in pygame.event.get():
            if event.type == pygame.QUIT:
                pygame.quit()
                exit()
            if event.type == pygame.MOUSEBUTTONDOWN:
                if button_rect.collidepoint(event.pos):
                    waiting = False

running = True
enemy_upgraded = False
show_start_screen()

while running:
    screen.fill((0, 0, 0))
    screen.blit(background, (0, 0))

    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            running = False

        if event.type == pygame.KEYDOWN:
            if event.key == pygame.K_LEFT:
                playerX_change = -1
            if event.key == pygame.K_RIGHT:
                playerX_change = 1
            if event.key == pygame.K_SPACE and bullet_state == "ready":
                bullet_Sound = mixer.Sound('laser.wav')
                bullet_Sound.play()
                bulletX = playerX
                fire_bullet(bulletX, bulletY)

        if event.type == pygame.KEYUP:
            if event.key in [pygame.K_LEFT, pygame.K_RIGHT]:
                playerX_change = 0

    playerX += playerX_change
    playerX = max(0, min(playerX, 736))

    if score_value >= 5 and not enemy_upgraded:
        for i in range(num_of_enemies):
            enemyImg[i] = pygame.transform.scale(pygame.image.load('enemy2.png'), (50, 50))
            enemyX_change[i] = 0.6 if enemyX_change[i] > 0 else -0.6
        score_color = (255, 0, 0)
        enemy_upgraded = True

    if score_value >= 10 and not boss_active:
        boss_active = True
        label_text = "Life"
        score_color = (255, 255, 0)

    for i in range(num_of_enemies):
        if enemyY[i] > 440 and not boss_active:
            for j in range(num_of_enemies):
                enemyY[j] = 2000
            game_over_text()
            running = False
            break

        enemyX[i] += enemyX_change[i]
        if enemyX[i] <= 0 or enemyX[i] >= 736:
            enemyX_change[i] *= -1
            enemyY[i] += enemyY_change[i]

        if isCollision(enemyX[i], enemyY[i], bulletX, bulletY):
            explosion_Sound = mixer.Sound('explosion.wav')
            explosion_Sound.play()
            bulletY = 480
            bullet_state = "ready"
            score_value += 1
            enemyX[i] = random.randint(0, 736)
            enemyY[i] = random.randint(50, 150)

        if not boss_active:
            enemy(enemyX[i], enemyY[i], i)

    if bulletY <= 0:
        bulletY = 480
        bullet_state = "ready"

    if bullet_state == "fire":
        fire_bullet(bulletX, bulletY)
        bulletY -= bulletY_change

    if boss_active:
        bossX += bossX_change
        if bossX <= 0 or bossX >= 720:
            bossX_change *= -1

        if isCollision(bossX, bossY, bulletX, bulletY):
            explosion_Sound = mixer.Sound('explosion.wav')
            explosion_Sound.play()
            bulletY = 480
            bullet_state = "ready"
            boss_life -= 1
            if boss_life <= 0:
                boss_active = False
                you_win_text()
                running = True

        screen.blit(bossImg, (bossX, bossY))

    player(playerX, playerY)
    show_label(textX, textY, label_text, score_value if not boss_active else boss_life, score_color)
    pygame.display.update()
