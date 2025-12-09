import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit,signal } from '@angular/core';
import { lastValueFrom } from 'rxjs';

@Component({
  selector: 'app-root',
  imports: [],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit{

// OnInit je interface i lifecycle hook

//dependency injection HttpClient-a u 
 // constructor(private http: HttpClient){  ovo je staro, Angular imna novu inject 

  private http = inject(HttpClient);
  protected title = 'Dating app';
  protected members= signal<any>([]); // any je iz javascripta a ne iz typescripta

  async ngOnInit() {
    this.members.set(await this.getMembers())
    // HTTP REQUEST   vraca observable , ako hocemo da observe observable moramo se subscribe,
    //  i moramo se unsubscribe inace da oslobodimo resurse browsera, ali za HTTP ne moramo
    //jer to ide automatski sa HTTP requestovima, nego samo streamovima podataka 
  }
  //u JS ne treba await ako metoda vraca promise
  async getMembers(){
    try{
      return lastValueFrom(this.http.get('https://localhost:5001/api/members'));
    }
    catch(error){
      console.log(error);
      throw error;
    }
  }

}
