ENTREGA FINAL

En esta entrega final tuvimos el desafío de tomar todo el feedback entregado a nosotros en las correcciones
de las dos entregas anteriores y asegurarnos de darle un buen uso a dicha información para conseguir un producto
terminado y presentable tanto ante los profesores así como ante los colaboradores de la materia. Estas últimas
semanas de desarrollo estuvieron llenas de altos y bajos, entre ellos la frustración de tener que hacer funcionar
nuestro código en el bot de Telegram, la serializacion (la cual fue la más notable de nuestros problemas, de la 
cual conseguimos serializar pero no deserializar los archivos), sin embargo no todo fueron malos momentos, pudimos
vernos más eficientes a la hora de enfrentar las adversidades antes mencionadas, así como muchas otras, por ejemplo
el añadir nuevos handlers a la Chain of Responsibility y los tests que dichos handlers requerian fue mucho más sencillo
que en la entrega anterior, pudimos modificar los handlers de tal manera que el mismo usuario tuviera un estado "state",
el cual le informa al programa en que handler y en que estado de dicho handler se encuentra el usuario, lo que permite que el bot 
pueda ser utilizado por varios usuarios a la vez. También nos aseguramos de que los tests funcionaran correctamente, verificando 
que los datos de las distintas clases cambian efectivamente (cosa que no pudimos realizar en la entrega anterior) así asegurandonos
que clases que usamos como herramientas (por ej. la clase buscador) esten funcionando acorde a lo esperado, y nos llevamos la satisfacción 
de que nuestro producto GreenResourceBot funcionara correctamente y pueda manejar muchos casos adversos con la inclusion de excepciones 
las cuales no habíamos implementado en la etapa anterior del proyecto. 
Nos aseguramos de mejorar tanto las convenciones (Usamos PascalCasing para las properties publicas y CamalCasing para las properties 
privadas), así como de actualizar nuestro diagrama UML para que representar con mayor fidelidad el modelo actual del producto. 
Tristemente no pudimos mantener la funcionalidad adecuada de la LocationApi después de la actualización a la misma brindada por los profesores 
posterior a la segunda entrega, aún así la mayor lección que nos llevamos de este proyecto, es la experiencia de un desarrollo en el cual nos 
vimos forzados a superarnos a nosotros mismos constantemente y adaptarnos a las distintas situaciones que enfrenatmos en el transcurso del 
semestre, así como a la metodología de las convenciones y patrones de desarrollo para llevar a cabo un producto, sustentable, sólido, expandible, 
y accesible para los otros desarrolladores a la hora de entenderlo (no solo para facilitar la evaluación del mismo, sino también en el hipotético 
caso de que otros desarroladores tuvieran que integrarse al desarrollo del producto). Independientemente del resultado final que reciba esta entrega, 
estamos orgullosos tanto de nuestro equipo como de nuestro trabajo.

SEGUNDA ENTREGA

En esta segunda entrega debido al hecho de tener que llevar a la práctica las ideas establecidas en la
primera entrega en nuestro diagrama de clases y tarjetas CRC atravesamos ciertas dificultades a la hora
de empezar a aplicar la lógica necesaria en las clases para que nuestro programa empezara a tomar forma,
si bien esta etapa de adaptación fue bastante complicada. Intentamos implementar el patrón Creator, 
sin embargo este generó muchos problemas en los test dando el error "NullReferenceObject", por lo que nos 
vimos obligados a desisitir a la idea de implementar dicho patrón a efectos de esta entrega. 
Dejando eso de lado una vez empezamos a aplicar los patrones correctos uno de los más notables entre ellos 
fue Chain of Responsibility, el cual nos ayudó a ahorrar mucho código innecesario y a darnos cuenta que 
muchas clases que habíamos creido necesarias previo a utilizar este patrón quedaban obsoletas ante la 
implementación del mismo(algunas de las clases que quedaron obsoletas fueron Conversacion, Comandos y 
IComandos por ejemplo) esto facilitó en gran medida el desarrollo de esta segunda entrega e hizo que 
otro obstáculo que tuvimos más tarde el cual fue la LocationApi fuera mucho más manejable de lo que hubiera 
sido con muchas más clases interactuando innecesariamente con la misma. Los test presentaron ciertas dificultades
a la hora de interactuar con la LocationApi, pero más allá de eso no presentaron un problema mayor.
Esta entrega nos permitió seguir mejorando como desarrolladores a la hora de ser más eficientes buscando soluciones
y a identificar clases o partes del código que quedan obsoletas, a su vez también mejoramos a la hora de hacer tests 
y a la hora de interactuar con Apis. Una gran ayuda en nuestro desarrollo a lo largo de esta entrega fueron las clases
de consulta dadas por el profesor, la demo del bot de Telegram también presentada por los profesores y el sitio también 
recomendado por los mismos "Refactoring Guru". 

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