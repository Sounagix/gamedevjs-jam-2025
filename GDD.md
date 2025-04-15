# Game Design Document (GDD)

## Género
Autobattler Estratégico (inspirado en Teamfight Tactics, con ambientación de fantasía clásica)

---

## Concepto General
Es un juego de estrategia por turnos en el que los jugadores colocan unidades en un tablero antes de cada ronda de combate automático. Cada unidad pertenece a una clase (Tanque, Healer, Mago o Arquero) y a una facción (reinos, clanes, escuelas mágicas, etc.). El objetivo es formar sinergias entre unidades, administrar recursos y sobrevivir más rondas que los oponentes.

---

## Plataformas
- **PC**
- **Móvil (iOS y Android)**
- **WebGL** (versión ligera para navegadores)

---

## Mecánicas de Juego

### 1. Fase de Planeación
- Colocación de unidades en el tablero.
- Compra de unidades con "oro".
- Combinación de unidades iguales para subir de nivel.
- Activación de sinergias por clase o facción.

### 2. Fase de Combate
- El combate ocurre de forma automática.
- Unidades con atributos (vida, ataque, velocidad, etc.).
- Habilidades automáticas con carga de maná.
- Finaliza al eliminar todas las unidades del rival.

### 3. Progresión y Eliminación
- Cada jugador posee puntos de vida totales.
- Al perder una ronda, se recibe daño proporcional a unidades enemigas restantes.

---

## Clases de Unidades

### Tanques
- Alta vida y armadura.

### Healers
- Curaciones en área o individuales.
- Poca defensa, deben ser protegidos.

### Magos
- Daño alto en área mediante habilidades.
- Requieren buen posicionamiento y maná.

### Picaros

* **Rangers**: Unidades de ataque a distancia con alta velocidad de ataque.

* **Assasins**: Se reposicionan al inicio del combate para atacar la retaguardia enemiga.

---

## Facciones

- **Bosque Eterno**: Regeneración natural de salud.
- **Legión de Acero**: Mejora de armadura y defensa.
- **Academia Arcana**: Habilidades mágicas potenciadas.
- **Tribu Sombría**: Velocidad y bonificaciones de daño.

---


## Bosque Eterno

### 1. **Elaren, Guardián del Roble**
- **Clase:** Tanque  
- **Descripción:** Provoca enemigos cercanos y regenera vida constantemente. Muy resistente, ideal para la primera línea.

### 2. **Nymira, Sanadora de la Bruma**
- **Clase:** Healer  
- **Descripción:** Cura a los aliados más cercanos con el poder del rocío. Puede disipar efectos negativos.

### 3. **Thalor, Arquero de Musgo**
- **Clase:** Arquero  
- **Descripción:** Sus flechas ralentizan a los enemigos y aplican veneno con cada impacto consecutivo.

### 4. **Faëlin, Maga Silvestre**
- **Clase:** Mago  
- **Descripción:** Invoca raíces que emergen del suelo, inmovilizando y dañando a enemigos en área.

---

## Legión de Acero

### 1. **Garron, Escudo de Hierro**
- **Clase:** Tanque  
- **Descripción:** Proyecta una barrera que reduce el daño recibido por su equipo durante varios segundos.

### 2. **Verna, Comandante de Batallón**
- **Clase:** Ranger  
- **Descripción:** Gana velocidad de ataque cada vez que elimina a un enemigo.

### 3. **Redox, Artillero del Núcleo**
- **Clase:** Mago  
- **Descripción:** Lanza proyectiles explosivos de energía que dañan en área.

### 4. **Kaelrum, Sargento Médico**
- **Clase:** Healer  
- **Descripción:** Cura a un aliado gravemente herido y le otorga un escudo temporal. Muy útil en finales de ronda.

---

## Academia Arcana

### 1. **Aelira, Maga de Hielo**
- **Clase:** Mago  
- **Descripción:** Lanza conjuros de escarcha que ralentizan e incluso congelan a sus enemigos.

### 2. **Milo, Aprendiz Caótico**
- **Clase:** Healer  
- **Descripción:** Cura o potencia a aliados con resultados aleatorios pero poderosos. Caos total.

### 3. **Kaeldros, Custodio del Portal**
- **Clase:** Tanque  
- **Descripción:** Se teletransporta a proteger aliados en peligro, absorbiendo su daño.

### 4. **Syra, Asesina Etérea**
- **Clase:** Asesina  
- **Descripción:** Al matar o participar en una muerte enemiga, Syra salta a un enemigo aleatorio.

---

## Tribu Sombría

### 1. **Zarak, Acechador Nocturno**
- **Clase:** Asesina  
- **Descripción:** Ataca desde las sombras con un crítico garantizado al inicio.

### 2. **Sylha, Espíritu de la Niebla**
- **Clase:** Healer  
- **Descripción:** Cura en área y es intargeteable durante su habilidad. Ideal para resistir ataques masivos.

### 3. **Dren, Hijo del Silencio**
- **Clase:** Mago  
- **Descripción:** Lanza una sombra que silencia enemigos en un área y les inflige daño progresivo.

### 4. **Kraven, Cazador Lunar**
- **Clase:** Tanque  
- **Descripción:** Gana evasión y reflejo de daño cuando está rodeado, convirtiéndose en un protector agresivo.

---

## Estadísticas de Personajes

Cada unidad cuenta con un conjunto de estadísticas que determinan su comportamiento en combate. Estas estadísticas pueden mejorar al subir de nivel (combinando 3 unidades iguales) o mediante sinergias y objetos.

### Estadísticas Básicas

| Estadística        | Descripción                                                                 |
|--------------------|-----------------------------------------------------------------------------|
| **Vida (HP)**       | Determina cuántos puntos de daño puede recibir antes de ser derrotada.      |
| **Daño de Ataque**  | Daño físico infligido con cada ataque básico.                              |
| **Velocidad de Ataque** | Determina cuántos ataques realiza por segundo.                        |
| **Maná Inicial**     | Cantidad de maná con la que empieza la unidad al inicio de la ronda.      |
| **Maná Máximo**      | Cantidad total de maná que necesita para lanzar su habilidad.             |
| **Regeneración de Maná** | Maná ganado por cada ataque básico o al recibir daño.              |
| **Alcance**          | Distancia a la que puede atacar (cuerpo a cuerpo o a distancia).          |
| **Velocidad de Movimiento** | Afecta la rapidez con la que se reposiciona en combate.         |

### Estadísticas Defensivas

| Estadística        | Descripción                                                                 |
|--------------------|-----------------------------------------------------------------------------|
| **Armadura**        | Reduce el daño físico recibido.                                             |
| **Resistencia Mágica** | Reduce el daño mágico recibido.                                         |
| **Evasión**         | Probabilidad de esquivar un ataque básico (especial para asesinos).         |
| **Bloqueo**         | Probabilidad de reducir parcialmente el daño recibido (tanques).            |

### Estadísticas Avanzadas (Condicionales o por sinergias)

| Estadística        | Descripción                                                                 |
|--------------------|-----------------------------------------------------------------------------|
| **Crítico**         | Probabilidad de realizar un golpe crítico con ataque básico.                |
| **Daño Crítico**    | Multiplicador de daño al realizar un golpe crítico.                         |
| **Robo de Vida**    | Porcentaje del daño infligido que se convierte en curación.                 |
| **Penetración de Armadura** | Ignora parte de la armadura del enemigo.                          |
| **Reducción de Enfriamiento** | Reduce el tiempo entre uso de habilidades (magos, rangers).     |

---

> *Nota:* Algunas estadísticas pueden estar restringidas o potenciadas según la clase. Por ejemplo:
> - Tanques tienden a tener mayor **vida** y **bloqueo**.
> - Healers priorizan **maná** y **alcance**.
> - Asesinos tienen alta **evasión**, **crítico** y **velocidad de ataque**.
> - Rangers escalan con **velocidad de ataque** y **daño crítico**.
> - Magos dependen de **maná máximo** y **reducción de enfriamiento**.


---

## Sistema de Sinergias

Activación de efectos especiales por cantidad de unidades en campo:

```markdown
Ejemplo:
- 2 Magos: +10% poder de habilidad
- 4 Magos: +25% poder de habilidad y regeneración de maná
- 2 Tanques: +20% armadura
- 4 Tanques: +20% armadura y provocación inicial
```

---

## Estilo Visual
- Gráficos ...TODO
- Tablero flotante con paisajes fantásticos.
- Efectos visuales llamativos y claros.

---

## Interfaz de Usuario
- Tienda con rotación aleatoria de unidades.
- Panel de sinergias activas.
- Indicadores de salud, oro y experiencia.

![](./HUD.png)


---

## Referencias
- *Teamfight Tactics*
- *Dota Underlords*
- *Auto Chess*
- *Hearthstone Battlegrounds*
