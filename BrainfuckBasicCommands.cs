using System;
using System.Collections.Generic;
using System.Linq;

namespace func.brainfuck
{
	public class BrainfuckBasicCommands
	{
        Dictionary<byte, char> dictionary = new Dictionary<byte, char>();

        public static void RegisterTo(IVirtualMachine vm, Func<int> read, Action<char> write)
		{
            
			vm.RegisterCommand('.', b => 
            {
                write((char)vm.Memory[vm.MemoryPointer]);
            });
			vm.RegisterCommand('+', b => 
            {
                if (vm.Memory[vm.MemoryPointer] == 255)
                    vm.Memory[vm.MemoryPointer] = 0;
                else
                    vm.Memory[vm.MemoryPointer]++;
            });
			vm.RegisterCommand('-', b => 
            {
                if (vm.Memory[vm.MemoryPointer] == 0)
                    vm.Memory[vm.MemoryPointer] = 255;
                else
                    vm.Memory[vm.MemoryPointer]--;
            });
            vm.RegisterCommand('>', b =>
            {
                if (vm.MemoryPointer == vm.Memory.Length - 1)
                    vm.MemoryPointer = 0;
                else
                    vm.MemoryPointer++;
            });
            vm.RegisterCommand('<', b =>
            {
                if (vm.MemoryPointer == 0)
                    vm.MemoryPointer = vm.Memory.Length - 1;
                else
                    vm.MemoryPointer--;
            });
        }
	}
}
