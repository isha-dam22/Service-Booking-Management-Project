import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ServicereporlistComponent } from './servicereporlist.component';

describe('ServicereporlistComponent', () => {
  let component: ServicereporlistComponent;
  let fixture: ComponentFixture<ServicereporlistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ServicereporlistComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ServicereporlistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
