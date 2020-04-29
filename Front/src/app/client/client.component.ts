import { Component, OnInit, Input } from '@angular/core';
import { Client } from '../shared/client.model';
import { DataService } from '../data.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.scss']
})
export class ClientComponent implements OnInit {

  @Input() client: Client;

  constructor(private dataService: DataService) {
    this.client = 
      {
        "IdCliente": 0,
        "Identifiacion": null,
        "Nombres": null,
        "Apellidos": null,
        "Direccion": null,
        "Telefono": null,
        "Email": null
      };
  }

  getClientById(id: number){
      if(id != null && id != 0){
        this.dataService.getClientById(id).subscribe(data => {
          // Make a deep copy of the original data to keep it immutable
          this.client = data;
        },(err) => {
          Swal.fire('El cliente con identificacion: ' + id + ' no existe', "Antojitos", 'error');
          this.client = 
          {
            "IdCliente": 0,
            "Identifiacion": null,
            "Nombres": null,
            "Apellidos": null,
            "Direccion": null,
            "Telefono": null,
            "Email": null
          };
        },()=>{
          this.dataService.setSession(this.client);
        });
    }
  }

  ngOnInit() {
  }
}