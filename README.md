# Archaea
Project Name: ARCHAEA - Mental Health Resilience Augmentation of Workforce by AI and VR-powered Co-/Bio-Sensing
Archaea project focuses on the specific challenge of the disconnection between the selection of the right psycho-therapeutic strategy and the root cause of the symptoms. Employees with mental problems usually reflect the invisible root causes (e.g. maladaptive primary emotions) to visible/obvious and solidified symptoms or symbols (e.g., impulsiveness, anxiety). The main goal of Archaea is to improve the workforce by identifying the right causes of mental disorders and accelerating work engagement.  
![image](https://github.com/PatikaPsikoloji/Archaea/assets/24838569/65cf0b77-83cc-4210-a478-38957fe776f7)

The proposed solution will first focus on a generalised semantic modelling (ontology) of the widely adopted preliminary interview questions, psychological tests, and the classification of mental disorders and their visible symbolic reflectors. This model will be the basis of the combined utilisation of co-sensing and bio-sensing to identify the root cause of a mental disorder negatively affecting workforce performance.
Co-sensing is the mainstream therapy method that evaluates the verbal, emotional, gestural and behavioural reactions strengthened with therapist-participant interaction, questionnaires and psychological tests. On the other hand, biosensing is a new paradigm that acquires physiological reactions of the subject (EEG, ECG, respiration, perspiration) against external/internal stressors. 
Archea will help acquire privacy/security-aware co/bio-sensing data during the first interview and assist the therapist in identifying the upmost causes of the problem by using an AI-powered data analysis tool. Once the most probable causes are identified, a Virtual Reality (VR) scene will be prepared to visualise the perceptional pieces of evidence of the root causes.  For example, if a person suffers from social phobia and one of the possible root causes is his teacher’s humiliation having glasses and a moustache, an auto-generated symbolic illustration of such a teacher will be exposed in a virtual environment.
In the second interview, this VR scenario will be animated to the client to verify the most crucial root causes of the mental disorder by applying co/bio-sensing in the meantime. By doing so, we will have a mostly-verified assistive interpretation of the main causes of the mental disorder.

![image](https://github.com/PatikaPsikoloji/Archaea/assets/24838569/0e75a490-bf62-42e7-9482-71c6bbc435eb)

This repository includes: 
1. Agent-based data acquisition utilities which are based on IoFog (https://iofog.org/)
2. A sample unity project that applies basic VR-based exposing in a 3d environment strengthened with AI-based image generation (STABLE DIFFUSION XL, https://clipdrop.co/apis)

PS: We are planning to improve this Github repository with the following tools if we get funded:
- Co-sensing Interview and Bio-sensing Data Acquisition (with an ontology and semantic backend to be realised with Virtuoso, Kafka, IoFog)
- Explainable AI services
- Cryptography and authentication service (KeyCloak https://github.com/keycloak/keycloak + Sun PKCS11 library: https://github.com/openjdk/jdk/blob/master/src/jdk.crypto.cryptoki/share/classes/sun/security/pkcs11/wrapper/PKCS11.java)
