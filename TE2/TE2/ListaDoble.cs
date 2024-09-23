using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE2
{
    public interface IList
    {
        void InsertInOrder(int value);       // Inserta un valor en orden ascendente
        int DeleteFirst();                   // Elimina y retorna el primer elemento
        int DeleteLast();                    // Elimina y retorna el último elemento
        bool DeleteValue(int value);         // Elimina un valor específico
        int GetMiddle();                     // Obtiene el valor central
        void MergeSorted(IList listA, IList listB, SortDirection direction);  // Mezcla dos listas
    }
    public class Nodo
    {
        public int Value { get; set; }
        public Nodo? Next { get; set; }
        public Nodo? Previous { get; set; }

        public Nodo(int value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }
    }

    public enum SortDirection
    {
        Asc,
        Desc
    }

    public class ListaDoble : IList
    {
        private Nodo? head;
        private Nodo? tail;
        private Nodo? middle;
        private int size;

        public ListaDoble()
        {
            head = null;
            tail = null;
            middle = null;
            size = 0;
        }

        // Inserta un valor en orden ascendente
        public void InsertInOrder(int value)
        {
            Nodo newNode = new Nodo(value);
            if (head == null)
            {
                head = tail = middle = newNode;
            }
            else
            {
                Nodo? current = head;
                while (current != null && current.Value < value)
                {
                    current = current.Next;
                }

                if (current == null) // Insertar al final
                {
                    tail!.Next = newNode;
                    newNode.Previous = tail;
                    tail = newNode;
                }
                else if (current == head) // Insertar al principio
                {
                    newNode.Next = head;
                    head.Previous = newNode;
                    head = newNode;
                }
                else // Insertar en medio
                {
                    Nodo? prev = current.Previous;
                    newNode.Next = current;
                    newNode.Previous = prev;
                    prev!.Next = newNode;
                    current.Previous = newNode;
                }

                // Ajustar el rastro del nodo medio
                if (size % 2 == 0)
                {
                    middle = middle?.Previous;
                }
            }
            size++;
        }
        public void InsertLast(int value)
        {
            Nodo newNode = new Nodo(value);

            if (tail == null) // Lista vacía
            {
                head = tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Previous = tail; // Cambiado a Previous
                tail = newNode;
            }

            size++;
            // Opcional: Si no necesitas actualizar el nodo medio, elimina esta línea.
            // UpdateMiddle();
        }


        // Elimina y retorna el primer elemento
        public int DeleteFirst()
        {
            if (head == null)
            {
                throw new InvalidOperationException("La lista está vacía.");
            }

            int value = head.Value;
            if (head == tail)  // Si la lista tiene un solo elemento
            {
                head = tail = middle = null;
            }
            else
            {
                head = head.Next;
                if (head != null) head.Previous = null;
            }

            size--;
            return value;
        }


        // Elimina y retorna el último elemento
        public int DeleteLast()
        {
            if (tail == null)
            {
                throw new InvalidOperationException("La lista está vacía.");
            }

            int value = tail.Value;
            if (head == tail)  // Si la lista tiene un solo elemento
            {
                head = tail = middle = null;
            }
            else
            {
                tail = tail.Previous;
                if (tail != null) tail.Next = null;
            }

            size--;
            return value;
        }

        // Elimina un valor específico
        public bool DeleteValue(int value)
        {
            if (head == null)
            {
                throw new InvalidOperationException("La lista está vacía.");
            }

            Nodo? current = head;
            while (current != null && current.Value != value)
            {
                current = current.Next;
            }

            if (current == null) return false;  // Valor no encontrado

            if (current == head) DeleteFirst();
            else if (current == tail) DeleteLast();
            else
            {
                current.Previous!.Next = current.Next;
                current.Next!.Previous = current.Previous;
            }

            size--;
            return true;
        }

        // Obtiene el elemento central
        public int GetMiddle()
        {
            if (head == null)
            {
                throw new InvalidOperationException("La lista está vacía.");
            }

            Nodo? slow = head;
            Nodo? fast = head;

            // Usamos dos punteros: uno que se mueve el doble de rápido que el otro
            while (fast != null && fast.Next != null)
            {
                slow = slow?.Next; // Mueve lento una posición
                fast = fast.Next.Next; // Mueve rápido dos posiciones
            }

            return slow?.Value ?? throw new InvalidOperationException("Error al calcular el nodo central.");
        }


        // Mezcla dos listas en orden ascendente o descendente
        // Mezcla dos listas en orden ascendente o descendente
        public void MergeSorted(IList listA, IList listB, SortDirection direction)
        {
            if (listA == null || listB == null)
            {
                throw new ArgumentNullException("Las listas no pueden ser nulas.");
            }

            if (listA is not ListaDoble listaA || listB is not ListaDoble listaB)
            {
                throw new InvalidOperationException("Las listas deben ser del tipo ListaDoble.");
            }

            Nodo? currentA = listaA.head;
            Nodo? currentB = listaB.head;

            ListaDoble mergedList = new ListaDoble();

            if (direction == SortDirection.Asc)
            {
                // Fusión en orden ascendente
                while (currentA != null && currentB != null)
                {
                    if (currentA.Value < currentB.Value)
                    {
                        mergedList.InsertLast(currentA.Value); // Insertar al final para mantener el orden ascendente
                        currentA = currentA.Next;
                    }
                    else
                    {
                        mergedList.InsertLast(currentB.Value); // Insertar al final
                        currentB = currentB.Next;
                    }
                }
            }
            else // SortDirection.Desc
            {
                // Fusión en orden descendente
                while (currentA != null && currentB != null)
                {
                    if (currentA.Value > currentB.Value)
                    {
                        mergedList.InsertLast(currentA.Value); // Insertar al final para mantener el orden descendente
                        currentA = currentA.Next;
                    }
                    else
                    {
                        mergedList.InsertLast(currentB.Value); // Insertar al final
                        currentB = currentB.Next;
                    }
                }
            }

            // Agregar los elementos restantes de listaA
            while (currentA != null)
            {
                mergedList.InsertLast(currentA.Value); // Insertar al final
                currentA = currentA.Next;
            }

            // Agregar los elementos restantes de listaB
            while (currentB != null)
            {
                mergedList.InsertLast(currentB.Value); // Insertar al final
                currentB = currentB.Next;
            }

            // Actualizar los punteros de la lista actual
            this.head = mergedList.head;
            this.tail = mergedList.tail;
            this.size = mergedList.size;
            this.middle = mergedList.middle;
        }


    }

}
