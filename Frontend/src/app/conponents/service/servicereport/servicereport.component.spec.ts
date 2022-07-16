import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ServicereportComponent } from './servicereport.component';

describe('ServicereportComponent', () => {
  let component: ServicereportComponent;
  let fixture: ComponentFixture<ServicereportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ServicereportComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ServicereportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
