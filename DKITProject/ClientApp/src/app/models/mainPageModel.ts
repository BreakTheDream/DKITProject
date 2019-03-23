import { NewPreview } from './new';
import { SpecialityPreviewModel } from './speciality';
import { Partner } from './partner';
import { Certificate } from './certificate'; 

export class MainPageModel {
    news: NewPreview[];
    specialties: SpecialityPreviewModel[];
    partners: Partner[];
    certificates: Certificate[];
}