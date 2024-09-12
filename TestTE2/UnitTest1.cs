using Microsoft.VisualStudio.TestTools.UnitTesting;
using TE2;
namespace TestTE2
{
    namespace ListaDobleTests
    {
        [TestClass]
        public class ListaDobleTests
        {
            private ListaDoble lista;

            [TestInitialize]
            public void Setup()
            {
                lista = new ListaDoble();
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

                int value = lista.DeleteFirst();
                Assert.AreEqual(1, value);
                Assert.AreEqual(2, lista.DeleteFirst());
                Assert.AreEqual(3, lista.DeleteFirst());
            }

            [TestMethod]
            public void TestDeleteLast()
            {
                lista.InsertInOrder(1);
                lista.InsertInOrder(2);
                lista.InsertInOrder(3);

                int value = lista.DeleteLast();
                Assert.AreEqual(3, value);
                Assert.AreEqual(2, lista.DeleteLast());
                Assert.AreEqual(1, lista.DeleteLast());
            }

            [TestMethod]
            public void TestDeleteValue()
            {
                lista.InsertInOrder(1);
                lista.InsertInOrder(2);
                lista.InsertInOrder(3);

                bool result = lista.DeleteValue(2);
                Assert.IsTrue(result);
                // Dependiendo de la implementación, podrías verificar el estado de la lista de otra manera
            }

            [TestMethod]
            public void TestGetMiddle()
            {
                lista.InsertInOrder(1);
                lista.InsertInOrder(2);
                lista.InsertInOrder(3);

                Assert.AreEqual(2, lista.GetMiddle()); // Ajusta según la lógica de tu método
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

                Assert.AreEqual(6, lista.DeleteFirst());
                Assert.AreEqual(5, lista.DeleteFirst());
                Assert.AreEqual(4, lista.DeleteFirst());
                Assert.AreEqual(3, lista.DeleteFirst());
                Assert.AreEqual(2, lista.DeleteFirst());
                Assert.AreEqual(1, lista.DeleteFirst());
            }
        }
    }

}