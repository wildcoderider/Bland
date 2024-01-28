import { Component } from '@angular/core';
import { UserService } from '../services/user.service';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatInputModule } from '@angular/material/input';
import { FormControl } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { MatNativeDateModule, MAT_DATE_FORMATS, DateAdapter } from '@angular/material/core';
import { DatePipe } from '@angular/common';


@Component({
  selector: 'app-user-settings',
  templateUrl: './user-settings.component.html',
  styleUrls: ['./user-settings.component.scss']
})
export class UserSettingsComponent {

  dateSelected?: string;
  userAge?: string = "No date selected yet";
  
  constructor(private userService: UserService, private datePipe: DatePipe){}

  dateControl = new FormControl();

  onDateChange(event: any) {
    const selectedDate = this.dateControl.value;

    const formattedDate = this.datePipe.transform(selectedDate, 'MM/dd/yyyy HH:mm:ss');
    
    console.log('Selected Date:', formattedDate);

    this.userService.getUserAge(formattedDate).subscribe(userAgeResponse => {
      this.userAge = userAgeResponse;
    });

    // Here, you can perform any action based on the selected date.
  }

  getUserAge(): void {

    const birthDate = this.dateSelected;
   
    this.userService.getUserAge(birthDate).subscribe(userAgeResponse => {
      this.userAge = userAgeResponse;
    });
  }

}
