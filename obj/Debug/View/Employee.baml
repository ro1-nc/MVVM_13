   M S B A M L   `   `   `  ????F  BMvvm_WPF_13, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Mvvm_WPF_13.ViewMvvm_WPF_13.View  5   	   =#clr-namespace:Mvvm_WPF_13.ViewModelMvvm_WPF_13.ViewModel  5   	       Mvvm_WPF_13.View.Employee   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Mvvm_WPF_13.View     5   	   2VM#clr-namespace:Mvvm_WPF_13.ViewModel     5   	     ? Title$  Employee??5	   	   $	??450??6   $	??800??6'    ? 	Resources 5
      -   'Mvvm_WPF_13.ViewModel.EmployeeViewModel   
EmployeeVM??%   &	          5   
   64   5      .??5      ??  ? DataContext# [  6   .+?5   
   ?? $??
Enter Name??6   ?? 5   
   ??6   ?? *Name+6*   ?? 5   
   $??	Enter DOB??6   ?? 5   
   ??6   ?? *DOB+6)   ?? 5   
   $??Search by Name??6   ?? 5   
   ??6   ?? *
FilterName+ ?? Mode$ TwoWay=? ?? UpdateSourceTrigger$ PropertyChanged=?6`   ?? 5   
   $??Search by Id??6   ?? 5   
   ??6   ?? *
FilterID+$ TwoWay=?$ PropertyChanged=?6^   ?? 5   
   $	??Add??6   $??20??6D   $??50??6P   ??6   ??  ?? Path$ ShowMessage?6]   ?? 5   
   $??Delete??6   $??20??6C   $??50??6O   ??6"   ?? $ Deleted?6\   ?? 5   
   -   5        $??Listbox??5      ??6"   ?? *Employee_list+ ?? SelectedIndex 6H   ?? *MyselectedIndex+ ?? View 5      ?? 5      -   5        Lemmesee??.P?5      ?? $??ID??6%    ?? DisplayMemberBinding 61   ?? *Id+6W   ?? 5      $
??Name??6%    63   ?? *Name+6[   ?? 5      $	??DOB??6%   	 ?? CellTemplate	 5       ?? 5!      .R?5"   "   ?? $??0q?6*   ??6>   ?? $	 DOB?6Z   5#      5%      5&      5(      5)      5*      