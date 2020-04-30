export class Tenant {
  public id: string;
  public createdDateTime: Date;
  public firstName: string;
  public lastName: string;
  public jobTitle: string;
  public phoneNumber: string;
  public nationality: string;
  public tenancyStartDate: Date;
  public notes: Array<Note>;
}

export class Note {
  public id: string;
  public createdDateTime: Date;
  public description: string;
}
