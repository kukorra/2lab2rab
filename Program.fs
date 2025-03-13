open System

let totalStringLength strings = 
    List.fold (fun acc str -> acc + String.length str) 0 strings

let generateRandomStrings count =
    let rnd = Random()
    let chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
    
    let randomString length =
        List.init length (fun _ -> chars.[rnd.Next(chars.Length)]) |> String.Concat
    List.init count (fun _ -> randomString (rnd.Next(3, 10))) 

let rec readStrings acc =
    printf "Введите строку (или пустую строку для завершения): "
    match Console.ReadLine() with
    | "" -> List.rev acc
    | input -> readStrings (input :: acc)

printf "Выберите способ ввода (1 - случайные строки, 2 - ввод вручную): "
match Console.ReadLine() with
| "1" ->
    let strings = generateRandomStrings 5
    printfn "Сгенерированные строки: %A" strings
    printfn "Суммарная длина строк: %d" (totalStringLength strings)
| "2" ->
    let strings = readStrings []
    printfn "Введенные строки: %A" strings
    printfn "Суммарная длина строк: %d" (totalStringLength strings)
| _ ->
    printfn "Некорректный выбор."
