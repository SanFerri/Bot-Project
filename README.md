PRIMERA ENTREGA

En esta primera entrega nos hemos centrado en definir el diagrama de clases y las tarjetas CRC necesarias 
para el apropiado desarrollo de nuestro chat bot, al principio tuvimos una visión muy simplista del 
proyecto, lo que nos llevó a imaginar muchas menos clases de las que en realidad serían necesarias para 
que nuestro chat bot cumpliera las indicaciones del desafío presentado por los profesores. Esto culminó 
con unas tarjetas CRC y un diagrama de clases que se sentían como que les faltaba algo para terminar de 
cerrar del todo. El momento más complicado que atravesamos como equipo en esta entrega fue cuando nos 
toco darnos cuenta de que lo que pensamos que era sencillo y ya estaba resuelto, en realidad era mucho 
más complejo de lo que nos esperabamos. Este momento de quiebre, también nos ayudo a progresar como 
desarrolladores, pues aprendimos que necesitabamos ampliar nuestra visión sobre como debe encararse un 
proyecto, y no solo buscar las opciones que a simple vista parecen más sencillas pero a la larga tal vez 
terminan causando más problemas que los que resuelven. Esto nos llevó a ampliar nuestro diagrama de 
clases y tarjetas CRC de manera de hacerlos más completos y responder nosotros dudas sobre el 
funcionamiento del bot que en las versiones anteriores de los mismo las dejabamos en el aire. Utilizamos 
la pagina web "Flowchart Maker & Online Diagram Software" la cual de una manera muy intuitiva nos ayudó a 
desarrollar nuestro nuevo diagrama de clases de una manera mucho más intuitiva, pudiendo desarrollar 
todas las interacciones entre los distintos aspectos del chatbot de una manera mucho más fiel a nuestra 
nueva visión y significativamente más clara, tanto para nosotros como esperamos que para el que estará 
leyéndolo. Para las tarjetas CRC utilizamos la herramienta CRC maker, mostrada durante las clases del 
curso.

SEGUNDA ENTREGA

En esta segunda entrega debido al hecho de tener que llevar a la práctica las ideas establecidas en la
primera entrega en nuestro diagrama de clases y tarjetas CRC atravesamos ciertas dificultades a la hora
de empezar a aplicar la lógica necesaria en las clases para que nuestro programa empezara a tomar forma,
si bien esta etapa de adaptación fue bastante complicada, una vez empezamos a aplicar los patrones correctos
uno de los más notables entre ellos fue Chain of Responsibility, el cual nos ayudó a ahorrar mucho código 
innecesario y a darnos cuenta que muchas clases que habíamos creido necesarias previo a utilizar este patrón 
quedaban obsoletas ante la implementación del mismo(algunas de las clases que quedaron obsoletas fueron 
Conversacion, Comandos y IComandos por ejemplo) esto facilitó en gran medida el desarrollo de esta segunda
entrega e hizo que otro obstáculo que tuvimos más tarde el cual fue la LocationApi fuera mucho más manejable
de lo que hubiera sido con muchas más clases interactuando innecesariamente con ella. Los test presentaron ciertas
dificultades a la hora de interactuar con la LocationApi, pero más allá de eso no presentaron un problema mayor.
Esta entrega nos permitió seguir mejorando como desarrolladores a la hora de ser más eficientes buscando soluciones
y a identificar clases o partes del código que quedan obsoletas, a su vez también mejoramos a la hora de hacer tests 
y a la hora de interactuar con Apis. Una gran ayuda en nuestro desarrollo a lo largo de esta entrega fueron las clases
de consulta dadas por el profesor, la demo del bot de Telegram también presentada por los profesores y el sitio también 
recomendado por los mismos "Refactoring Guru".
