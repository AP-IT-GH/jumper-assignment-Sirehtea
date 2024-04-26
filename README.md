
# Documentatie: Jumper Opdracht

*door: Turgay Yasar (s141475) & Ismail Khizirov (s142040)*

## Voorbereiding

1. Maak een nieuw unity project aan.
2. Installeer ML Agents via de Package Manager: Window --> Package Manager
bij packages links boven selecteer je "unity registry", nu zoek je naar de package ML Agents.

![alt text](image-4.png)

3. Bouw de volgende scene op:

![alt text](image-5.png)

![alt text](image-6.png)

4. Maak de volgende folders aan:

![alt text](image-7.png)

## Eigenshappen van de objecten

### MLPlayer

De agent is een kubus die de volgende componenten heeft:

- box collider: waarmee ons agent met andere objecten kan interageren
- rigidbody: simuleert zwaartekracht en andere fysieke krachten 
- decision requester: stuurt een AI-agent en neemt beslissingen op basis van sensoren
En gedrag
- ray perception sensor 3D: visualiseert in 3D laserstralen, waardoor de AI betere beslissingen kan nemem
- MLPlayer script: wordt later uitgelegd
- material: voor een kleurtje
- beschikt over de "ob" tag

![alt text](image-8.png)

![alt text](image-9.png)

![alt text](image-10.png)

### Obstacle

- rigidbody
- box collider
- material
- beschikt over een "obstacle" tag

![alt text](image-11.png)

![alt text](image-12.png)

### Road

- box collider
- material
- spawner script:

![alt text](image-13.png)

![alt text](image-14.png)

#### In de Road GameObject

![alt text](image-15.png)

##### SpawnPt

- heeft een icon

![alt text](image-16.png)

##### WallEnd

- box collider
- beschikt over een "wallend" tag
- zal dienen om aan te geven dat de MLPlayer op tijd heeft kunnen jumpen

![alt text](image-17.png)

##### Reset

- heeft een icon

![alt text](image-18.png)

##### WallTop

- box collider
- beschikt over een "walltop" tag

![alt text](image-19.png)

## Scripts

- MLPlayer script:

![alt text](image-22.png)

![alt text](image-23.png)

![alt text](image-24.png)

Dit script definieert het gedrag van een AI-agent in een Unity ML-Agents omgeving. De agent kan zich voortbewegen door te thrusten en verzamelt observaties. Het script beloont de agent voor het vermijden van de obstakels, en beëindigt een episode bij botsingen. Op deze manier wordt de AI getrained om de obstakels te ontwijken.

- Obstacle script:

![alt text](image-21.png)

Deze script definieert het gedrag van een obstakel. Het obstakel beweegt de hele tijd naar achteren met een snelheid bepaald door de variabele "MoveSpeed". Wanneer het obstakel een ander object raakt met de tag "wallend", wordt het vernietigd.

- Spawner script:

![alt text](image-20.png)

Deze script, genaamd "Spawner", zal om de zoveel tijd een prefab spawnen op een opgegeven spawnpositie binnen een gegeven tijdsinterval. Het gebruikt Invoke om de methode Spawn te herhalen na een willekeurige vertraging tussen de opgegeven minimale en maximale tijd. De "Spawn" methode instantieert de prefab op de spawnpositie en herhaalt vervolgens het proces. Hierdoor zal de prefab continu spawnen binnen het opgegeven tijdsinterval.

## Trainen van de agent

### Benodigdheden:

- anaconda environment
- laatste versie van unity
- in je unity folderstructuur (.../assets/config) maak je een config file aan met dit .yaml bestand:

![alt text](image-3.png)

### Te installeren (anaconda prompt)

- pip3 install torch~=1.7.1 -f
- python -m pip install mlagents==0.30.0

### AI trainen

```
mlagents-learn config/[naam].yaml --run-id=[te-kiezen]
```

Nadat je deze commando uitvoert op je anaconda prompt zal je gevraagd worden 

om in unity de play knop in te drukken.

![alt text](image-2.png)

## Bekijken van de resulataten via TensorBoard

![alt text](image-1.png)

```
tensorboard --logdir results --port 6006
```
Nadat je dit commando uitgevoerd hebt zal je een link krijgen die je redirzct naar je TensorBoard.

## Onze TensorBoard resultaten

![alt text](image.png)

Ons Agent had een lange tijd (1M stappen) om te leren. Het begon eerst met een negatieve waarde, maar naarmate de tijd begon het betere resulataten op te leveren. Soms had het een teruggang, maar bleef stijgen.