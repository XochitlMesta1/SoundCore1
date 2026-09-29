# SoundCore Engine GUI — DJ Queue & Transition Manager

**Data Structures — Unit 2 Challenge · TecNM Monclova**

A Windows Forms application that manages a DJ set queue using a **singly linked list built from scratch**, and compares it side by side with .NET's `LinkedList<T>` and `List<T>` (same interface, live benchmark). It can also play the audio files you import.

## Project structure

```
SoundCore/
├── Models/
│   └── Track.cs                 // Immutable track (Id, Title, Artist, Bpm, DurationSeconds, FilePath)
├── CustomStructures/
│   ├── Node.cs                  // Generic self-referencing node
│   ├── SinglyLinkedList.cs      // The 6 algorithms, from scratch
│   ├── IDJStructure.cs          // Common contract for the 3 structures
│   ├── LinkedListAdapter.cs     // .NET LinkedList<T>
│   └── ListTAdapter.cs          // .NET List<T>
├── Form1.cs                     // UI logic, synchronization, audio playback
└── Form1.Designer.cs            // WinForms layout
```

Engineering rules: the list is **decoupled** from Windows Forms, is **generic** (`SinglyLinkedList<T>`), and implements `IEnumerable<T>` with `yield return` for `DataGridView` binding.

## The 6 algorithms

| Method | Complexity | Description |
|---|---|---|
| `AddAtTheEnd(T)` | O(1) with `Tail` | Enqueues a track at the end of the set |
| `PlayNext(T)` | O(1) | Inserts right after the head ("Up Next", position 2) |
| `AdvanceTrack()` | O(1) | Removes the track that is playing and moves the head |
| `Invert()` | O(n) time, O(1) space | Strictly in-place, 3 pointers (`previous`, `current`, `next`) |
| `OrderInsert(T, cmp)` / `Order(cmp)` | O(n) / O(n²) | Sorted insertion by BPM; `Order` re-links the existing nodes (no temporary list) |
| `PurgeDuplicates(eq)` | O(n²) | Keeps the first occurrence, no `HashSet`, no arrays |

### Invert() — line by line

```csharp
Node<T> previous = null;
Node<T> current = Head;
Tail = Head;                       // the old head becomes the tail
while (current != null)
{
    Node<T> next = current.Next;   // 1. save the rest of the list
    current.Next = previous;       // 2. flip the arrow
    previous = current;            // 3. advance previous
    current = next;                // 4. advance current
}
Head = previous;                   // 5. new head
```

## How to run

1. Open the solution in Visual Studio (Windows).
2. Install NuGet packages: `NAudio` (audio playback) and `taglib` (reads title/artist/BPM tags).
3. Build and run.

## Using the app

- **Register fields + Enqueue at End:** adds a manual track (cannot be played, it has no audio file).
- **Enqueue at End with empty fields:** opens a file dialog to import your music (mp3, wav, flac, m4a, wma).
- **Play Next:** inserts the typed track at position 2.
- **Advance Track:** removes the head; if audio is playing, the next track starts.
- **Invert / Order by BPM / Purge Duplicates:** applied to the three structures at once.
- **Play / Pause / Stop:** plays the first track of the queue; when it ends, the next one starts automatically.
- **Mode radio buttons:** choose which structure is displayed (all three always hold the same data).
- **Test 25,000 Insertions:** benchmark with `Stopwatch`.

## Benchmark analysis

25,000 middle insertions (position 2):

- **Custom list / `LinkedList<T>` → O(1) per insertion:** they only re-point references; no data is moved.
- **`List<T>` → O(n) per insertion:** it is an array, so `Insert(1, x)` shifts every following element (`Array.Copy`), and the total cost grows with the size of the list.

Exact milliseconds depend on the machine; the gap between the linked lists and `List<T>` is what confirms the Big-O theory.

## Test cases

| ID | Scenario | Input | Expected result |
|---|---|---|---|
| CP-01 | Insert at end | "Track 1" (120 BPM) | Added as the last row of the grid |
| CP-02 | Up Next VIP | "Track VIP" | Placed at position 2 |
| CP-03 | Advance track | Click Advance | Head leaves the grid |
| CP-04 | In-place inversion | BPMs [100, 110, 120] | Grid shows [120, 110, 100] |
| CP-05 | BPM curve | 128, 115, 140, 120 | 115 → 120 → 128 → 140 |
| CP-06 | Purge duplicates | Repeated titles | Keeps the first, removes the rest |
| CP-07 | Error handling | Advance on empty queue | Informative MessageBox, no crash |
