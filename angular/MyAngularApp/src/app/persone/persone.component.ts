import { Component } from '@angular/core';
import { IPersoneBackEnd } from '../Interfacce/personeBackEnd';
import { PersoneService } from '../Service/personeService';
import { RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-persone',
  standalone: true,
  imports: [RouterOutlet, CommonModule],
  templateUrl: './persone.component.html',
  styleUrl: './persone.component.css'
})
export class PersoneComponent {

  personeBackEnd : IPersoneBackEnd[] = [];
  nomiColonne : string[] = [];

  constructor(private readonly personeService : PersoneService){}

  ngOnInit() : void{
    this.personeService.getAllPersone().subscribe( persone=>{
      this.personeBackEnd = persone;
      if(persone.length > 0)
      {
        this.nomiColonne = Object.keys(persone[0]);
      }
    })
  }
}
