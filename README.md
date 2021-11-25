# II-P5

Objetivo El objetivo de esta práctica es aprender a utilizar las herramientas de reconocimiento de voz que Unity3D ofrece para Windows 10. Para la utilización de estas herramientas se debe importar el paquete UnityEngine.Windows.Speech. Hay que tener en cuenta que este paquete sólo está disponible para el sistema operativo Windows 10. El enunciado copleto de la practica se puede encontrar en el documento: PrácticaReconocimientoVoz.pdf

## Implementacion:

Para la implementacion se han creado 6 scripts que controlan el juego. La logica de comunicacion a un nivel muy simplificado es:

![gamelogic](img/brickBrakerLogic.png)

### Reconozimiento de Palabras:

Para el reconocimiento de palabras se ha creado un dictionario que asocia las palabras que son registradas con funciones a ejecutar. Esto nos permite mas libertad cuando queremos expandir. En este ejemplo podemos controlar el paddel con commandos como "Left" y "Right" y podemos decir un numero para fijar el numero de saltos que hace el padel una vez que llega un commando de movimiento.

### Dictado de voz:
 
El dictado es utilizado para crear los bloques que se destruyen en el juego. Para esto tenemos los funciones startDictation, stopDictation y createBrickField, la ultima crea los bloques con characteres del dictado hecho.

## El juego:

Para la implemetacion de los objetivos pedidos he creado un pequeno juego, las reglas son similares al Brick Breaker con la diferencia que la bola no puede salir por abajo y que, ademas de poder movel el "paddel" con las teclas, se puede mover diciendo los keywords. Los bloques del juego son creados a partir del dictado que se hace, cada bloque presenta un character por lo cual la cantidad de characteres es limitado al tamano del juego (max 80 characteres).

El resto es muy similar, la bola se mueve a una velocidad, y si hay collision con un bloque, este sera eliminado.

### creacion del paddel:

### creacion de la bola:

### creacion de los bricks:
