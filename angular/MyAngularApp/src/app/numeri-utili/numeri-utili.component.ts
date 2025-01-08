import { Component } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { INumeriUtiliBackEnd } from '../Interfacce/numeriUtiliBackEnd';
import { NumeriUtiliService } from '../Service/numeriUtiliService';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-numeri-utili',
  standalone: true,
  imports: [RouterLink, RouterOutlet, CommonModule],
  templateUrl: './numeri-utili.component.html',
  styleUrl: './numeri-utili.component.css'
})
export class NumeriUtiliComponent {

  numeriUtiliBackEnd : INumeriUtiliBackEnd[] = [];
  nomiColonne : string [] = [];

  constructor(private readonly numeriUtiliService : NumeriUtiliService){}
  
  ngOnInit(): void{
    this.numeriUtiliService.getAllNumeriUtili().subscribe( numeri =>{
      this.numeriUtiliBackEnd = numeri;
      if (numeri.length > 0) {
        this.nomiColonne = Object.keys(numeri[0]);
        console.log('nomi colonne: ' + this.nomiColonne);
      }
      
    })
  }
}
