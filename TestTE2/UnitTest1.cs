using Microsoft.VisualStudio.TestTools.UnitTesting;
using TE2; // Asegúrate de que este espacio de nombres coincide con el de tu proyecto principal

namespace ListaDobleTest
{
    [TestClass]
    public class UnitTest1
    {
        private ListaDoble lista = new ListaDoble(); // Inicializa aquí para evitar el aviso CS8618

        // Método que se ejecuta antes de cada prueba
        [TestInitialize]
        public void Setup()
        {
            lista = new ListaDoble(); // Reinicializa antes de cada prueba
        }

        [TestMethod]
        public void TestInsertInOrder()
        {
            lista.InsertInOrder(3);
            lista.InsertInOrder(1);
            lista.InsertInOrder(2);

            Assert.AreEqual(1, lista.DeleteFirst());
            Assert.AreEqual(2, lista.DeleteFirst());
            Assert.AreEqual(3, lista.DeleteFirst());
        }

        [TestMethod]
        public void TestDeleteFirst()
        {
            lista.InsertInOrder(1);
            lista.InsertInOrder(2);
            lista.InsertInOrder(3);

            Assert.AreEqual(1, lista.DeleteFirst());
            Assert.AreEqual(2, lista.DeleteFirst());
            Assert.AreEqual(3, lista.DeleteFirst());

            // Verifica que la lista esté vacía
            Assert.ThrowsException<InvalidOperationException>(() => lista.DeleteFirst());
        }

        [TestMethod]
        public void TestDeleteLast()
        {
            lista.InsertInOrder(1);
            lista.InsertInOrder(2);
            lista.InsertInOrder(3);

            Assert.AreEqual(3, lista.DeleteLast());
            Assert.AreEqual(2, lista.DeleteLast());
            Assert.AreEqual(1, lista.DeleteLast());

            // Verifica que la lista esté vacía
            Assert.ThrowsException<InvalidOperationException>(() => lista.DeleteLast());
        }

        [TestMethod]
        public void TestDeleteValue()
        {
            lista.InsertInOrder(1);
            lista.InsertInOrder(2);
            lista.InsertInOrder(3);

            Assert.IsTrue(lista.DeleteValue(2));
            Assert.IsFalse(lista.DeleteValue(4)); // Valor no existente
        }

        [TestMethod]
        public void TestGetMiddle()
        {
            // Asegúrate de insertar valores en la lista antes de llamar a GetMiddle
            lista.InsertInOrder(1);
            lista.InsertInOrder(2);
            lista.InsertInOrder(3);

            // Verificación del valor medio correcto
            Assert.AreEqual(2, lista.GetMiddle());

            // Eliminar un elemento para probar si el medio cambia correctamente
            lista.DeleteFirst(); // Remueve el 1
            Assert.AreEqual(3, lista.GetMiddle());
        }


        [TestMethod]
        public void TestMergeSortedAsc()
        {
            ListaDoble listaA = new ListaDoble();
            listaA.InsertInOrder(1);
            listaA.InsertInOrder(3);
            listaA.InsertInOrder(5);

            ListaDoble listaB = new ListaDoble();
            listaB.InsertInOrder(2);
            listaB.InsertInOrder(4);
            listaB.InsertInOrder(6);

            lista.MergeSorted(listaA, listaB, SortDirection.Asc);

            Assert.AreEqual(1, lista.DeleteFirst());
            Assert.AreEqual(2, lista.DeleteFirst());
            Assert.AreEqual(3, lista.DeleteFirst());
            Assert.AreEqual(4, lista.DeleteFirst());
            Assert.AreEqual(5, lista.DeleteFirst());
            Assert.AreEqual(6, lista.DeleteFirst());
        }

        [TestMethod]
        public void TestMergeSortedDesc()
        {
            ListaDoble listaA = new ListaDoble();
            listaA.InsertInOrder(1);
            listaA.InsertInOrder(3);
            listaA.InsertInOrder(5);

            ListaDoble listaB = new ListaDoble();
            listaB.InsertInOrder(2);
            listaB.InsertInOrder(4);
            listaB.InsertInOrder(6);

            lista.MergeSorted(listaA, listaB, SortDirection.Desc);

            // Verificación del orden descendente
            Assert.AreEqual(6, lista.DeleteFirst());
            Assert.AreEqual(5, lista.DeleteFirst());
            Assert.AreEqual(4, lista.DeleteFirst());
            Assert.AreEqual(3, lista.DeleteFirst());
            Assert.AreEqual(2, lista.DeleteFirst());
            Assert.AreEqual(1, lista.DeleteFirst());
        }
    }
}
