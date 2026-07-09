# -*- coding: utf-8 -*-
"""
===============================================
   AI EDUCATIONAL TRANSFORMATION SYSTEM - GUI APPLICATION
===============================================

# GUIDE D'UTILISATION - DÉTAIL DES DONNÉES REQUISES

## DONNÉES EXACTES À SAISIR DANS CHAQUE CHAMP:

### 1. INFORMATIONS DE BASE
- Nom de l'école: Le nom officiel complet de l'établissement
- Région: La région géographique où se trouve l'école
- Type d'école: Public, Privé, ou Charter
- Niveaux: K-5 (Primaire), 6-8 (Moyen), ou 9-12 (Secondaire)

### 2. DONNÉES ACADÉMIQUES
- Nombre total d'étudiants: Effectif total actuel
- Nombre d'enseignants: Personnel enseignant permanent
- Score moyen en Mathématiques: Moyenne générale des notes de math
- Score moyen en Sciences: Moyenne générale des notes de sciences
- Score moyen en Lecture: Moyenne générale des notes de lecture
- Score moyen en Écriture: Moyenne générale des notes d'écriture
- Taux de réussite global: Pourcentage d'étudiants réussissant

### 3. DONNÉES FINANCIÈRES
- Budget annuel total: Budget total en dollars/an
- Dépenses par étudiant: Coût annuel par étudiant
- Salaires moyens des enseignants: Salaire moyen annuel

### 4. INFRASTRUCTURE
- Nombre de salles de classe: Total des salles disponibles
- Superficie totale: Surface en mètres carrés
- Nombre de laboratoires: Labs de sciences/informatique
- Nombre de bibliothèques: Espaces bibliothèque
- Accès Internet: Oui/Non

### 5. ENGAGEMENT ET PRÉSENCE
- Taux de présence: Pourcentage de présence quotidienne
- Taux de participation: Participation aux activités
- Nombre d'activités extrascolaires: Clubs et sports

### 6. RESSOURCES HUMAINES
- Ratio enseignant/étudiant: Nombre d'étudiants par enseignant
- Taux de rétention des enseignants: Pourcentage de renouvellement
- Heures de formation: Formation professionnelle annuelle

### 7. FACTEURS PSYCHOLOGIQUES
- Score de satisfaction: Enquête de satisfaction (1-10)
- Score de motivation: Niveau de motivation (1-10)
- Score de bien-être: Bien-être général (1-10)

## OÙ TROUVER CES DONNÉES:

### SOURCES PRIMAIRES:
1. **Système d'information scolaire (SIS)**: Données académiques et démographiques
2. **Rapports financiers annuels**: Budget et dépenses
3. **Registres de présence**: Données de fréquentation
4. **Évaluations standardisées**: Scores académiques
5. **Enquêtes scolaires**: Satisfaction et motivation
6. **Rapports d'inspection**: Infrastructure et ressources

### SOURCES SECONDAIRES:
1. **Ministère de l'Éducation**: Statistiques officielles
2. **District scolaire**: Rapports consolidés
3. **Études de marché**: Données comparatives
4. **Recherches académiques**: Benchmarks et normes

## INSTRUCTIONS PRATIQUES:

### POUR SAISIR UNE SEULE ÉCOLE:
1. Remplir tous les champs obligatoires (*)
2. Utiliser des formats numériques (pas de texte dans les champs numériques)
3. Pour les pourcentages: utiliser 0.85 pour 85%
4. Pour les montants: utiliser des chiffres entiers (ex: 50000)

### POUR IMPORTER UN FICHIER:
1. Préparer un fichier Excel/CSV avec les mêmes colonnes
2. Utiliser les mêmes noms de colonnes que dans le formulaire
3. Assurer la cohérence des formats de données
4. Importer le fichier via le bouton "Choisir un fichier"

## CONSEILS IMPORTANTS:
- La qualité des prédictions dépend de la qualité des données
- Les données manquantes ou incorrectes affectent les résultats
- Utiliser des données récentes pour des prédictions précises
- Vérifier la cohérence avant de soumettre

===============================================
"""

import streamlit as st
import pandas as pd
import numpy as np
import joblib
import plotly.express as px
import plotly.graph_objects as go
from plotly.subplots import make_subplots
import arabic_reshaper
from bidi.algorithm import get_display
import warnings
warnings.filterwarnings('ignore')

# Configuration de la page
st.set_page_config(
    page_title="AI Educational Transformation System",
    page_icon="schools",
    layout="wide",
    initial_sidebar_state="expanded"
)

# Style CSS pour l'interface arabe
st.markdown("""
<style>
    .rtl {
        direction: rtl;
        text-align: right;
        font-family: 'Arial', sans-serif;
    }
    .arabic-title {
        font-size: 2.5rem;
        font-weight: bold;
        color: #1f77b4;
        text-align: center;
        margin-bottom: 2rem;
    }
    .arabic-subtitle {
        font-size: 1.5rem;
        font-weight: bold;
        color: #ff7f0e;
        text-align: center;
        margin-bottom: 1rem;
    }
    .metric-card {
        background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
        padding: 1.5rem;
        border-radius: 10px;
        color: white;
        text-align: center;
        margin: 0.5rem 0;
    }
    .section-header {
        background: linear-gradient(90deg, #1f77b4, #ff7f0e);
        padding: 1rem;
        border-radius: 10px;
        color: white;
        margin: 1rem 0;
        text-align: center;
    }
    .success-message {
        background-color: #d4edda;
        border: 1px solid #c3e6cb;
        color: #155724;
        padding: 1rem;
        border-radius: 5px;
        margin: 1rem 0;
    }
    .warning-message {
        background-color: #fff3cd;
        border: 1px solid #ffeaa7;
        color: #856404;
        padding: 1rem;
        border-radius: 5px;
        margin: 1rem 0;
    }
    .error-message {
        background-color: #f8d7da;
        border: 1px solid #f5c6cb;
        color: #721c24;
        padding: 1rem;
        border-radius: 5px;
        margin: 1rem 0;
    }
</style>
""", unsafe_allow_html=True)

# Fonction pour afficher le texte arabe correctement
def arabic_text(text):
    if text:
        reshaped_text = arabic_reshaper.reshape(text)
        return get_display(reshaped_text)
    return text

# Fonction pour charger les modèles
@st.cache_resource
def load_models():
    try:
        models = {}
        models['rf'] = joblib.load('models/random_forest_model.joblib')
        models['xgb'] = joblib.load('models/xgboost_model.joblib')
        models['scaler'] = joblib.load('models/scaler.joblib')
        models['label_encoders'] = joblib.load('models/label_encoders.joblib')
        models['feature_names'] = joblib.load('models/feature_names.joblib')
        models['feature_importance'] = joblib.load('models/feature_importance.joblib')
        return models
    except Exception as e:
        st.error(f"Erreur lors du chargement des modèles: {e}")
        return None

# Fonction pour préparer les données
def prepare_data(input_data, models):
    try:
        # Convertir en DataFrame
        if isinstance(input_data, dict):
            df = pd.DataFrame([input_data])
        else:
            df = input_data.copy()
        
        # Encodage des variables catégorielles
        for col in df.select_dtypes('object').columns:
            if col in models['label_encoders']:
                df[col] = models['label_encoders'][col].transform(df[col])
        
        # S'assurer que toutes les colonnes requises sont présentes
        for col in models['feature_names']:
            if col not in df.columns:
                df[col] = 0
        
        # Réorganiser les colonnes
        df = df[models['feature_names']]
        
        # Mise à l'échelle
        df_scaled = models['scaler'].transform(df)
        
        return df_scaled
    except Exception as e:
        st.error(f"Erreur lors de la préparation des données: {e}")
        return None

# Fonction pour faire des prédictions
def predict_school_performance(input_data, models):
    try:
        # Préparer les données
        data_scaled = prepare_data(input_data, models)
        if data_scaled is None:
            return None
        
        # Prédictions
        rf_pred = models['rf'].predict(data_scaled)[0]
        xgb_pred = models['xgb'].predict(data_scaled)[0]
        
        # Moyenne des prédictions
        avg_pred = (rf_pred + xgb_pred) / 2
        
        return {
            'random_forest': rf_pred,
            'xgboost': xgb_pred,
            'average': avg_pred
        }
    except Exception as e:
        st.error(f"Erreur lors de la prédiction: {e}")
        return None

# Fonction pour générer des recommandations stratégiques
def generate_strategic_recommendations(prediction, input_data):
    score = prediction['average']
    
    # Déterminer le niveau de performance
    if score >= 80:
        level = "excellent"
        color = "#28a745"
    elif score >= 60:
        level = "good"
        color = "#ffc107"
    elif score >= 40:
        level = "average"
        color = "#fd7e14"
    else:
        level = "needs_improvement"
        color = "#dc3545"
    
    # Générer des recommandations basées sur le score et les données
    recommendations = {
        "student": {
            "title": "Stratégie pour les Étudiants",
            "actions": [
                "Programmes de tutorat personnalisés",
                "Activités de renforcement académique",
                "Groupes d'étude supervisés",
                "Programmes de mentorat par les pairs"
            ]
        },
        "teacher": {
            "title": "Stratégie pour les Enseignants",
            "actions": [
                "Formation pédagogique continue",
                "Ateliers sur les nouvelles méthodes d'enseignement",
                "Collaboration interdisciplinaire",
                "Utilisation des technologies éducatives"
            ]
        },
        "administration": {
            "title": "Stratégie pour l'Administration",
            "actions": [
                "Optimisation des ressources financières",
                "Planification stratégique à long terme",
                "Amélioration de l'infrastructure",
                "Développement des partenariats communautaires"
            ]
        },
        "library": {
            "title": "Stratégie pour la Bibliothèque",
            "actions": [
                "Enrichissement des collections numériques",
                "Programmes de littératie numérique",
                "Espaces d'apprentissage collaboratif",
                "Services de recherche avancée"
            ]
        }
    }
    
    return recommendations, level, color

# Interface principale
def main():
    # Titre principal
    st.markdown('<h1 class="arabic-title">AI Educational Transformation System</h1>', unsafe_allow_html=True)
    st.markdown('<h2 class="arabic-subtitle">Système de Transformation Éducative par IA</h2>', unsafe_allow_html=True)
    
    # Barre latérale
    st.sidebar.markdown("### Menu Principal")
    page = st.sidebar.selectbox(
        "Choisir une page:",
        ["Accueil", "Analyse d'École", "Analyse de Fichier", "À Propos"]
    )
    
    # Charger les modèles
    models = load_models()
    if models is None:
        st.error("Impossible de charger les modèles. Veuillez vérifier que les fichiers modèles existent.")
        return
    
    if page == "Accueil":
        show_home_page()
    elif page == "Analyse d'École":
        show_single_school_analysis(models)
    elif page == "Analyse de Fichier":
        show_batch_analysis(models)
    elif page == "À Propos":
        show_about_page()

def show_home_page():
    st.markdown('<div class="section-header">Bienvenue dans le Système de Transformation Éducative</div>', unsafe_allow_html=True)
    
    col1, col2 = st.columns(2)
    
    with col1:
        st.markdown("### Qu'est-ce que ce système?")
        st.write("""
        Ce système utilise l'intelligence artificielle pour:
        - Analyser la performance des écoles
        - Identifier les facteurs d'amélioration
        - Générer des recommandations stratégiques
        - Prédire les tendances futures
        """)
        
        st.markdown("### Comment l'utiliser?")
        st.write("""
        1. Entrez les données d'une école manuellement
        2. Ou importez un fichier Excel/CSV
        3. Obtenez une analyse complète et des recommandations
        """)
    
    with col2:
        st.markdown("### Caractéristiques Principales")
        st.write("""
        - Analyse par IA avancée
        - Visualisations interactives
        - Recommandations personnalisées
        - Support multilingue
        - Interface intuitive
        """)
        
        st.markdown("### Données Requises")
        st.write("""
        - Informations académiques
        - Données financières
        - Infrastructure
        - Engagement des étudiants
        - Ressources humaines
        """)

def show_single_school_analysis(models):
    st.markdown('<div class="section-header">Analyse d\'École Individuelle</div>', unsafe_allow_html=True)
    
    # Formulaire de saisie
    with st.form("school_data_form"):
        st.markdown("### Informations de Base")
        col1, col2, col3 = st.columns(3)
        
        with col1:
            school_name = st.text_input("Nom de l'école*", "École Exemple")
            region = st.selectbox("Région", ["North", "South", "East", "West", "Central"])
            school_type = st.selectbox("Type d'école", ["Public", "Private", "Charter"])
        
        with col2:
            grades = st.selectbox("Niveaux", ["K-5", "6-8", "9-12"])
            curriculum = st.selectbox("Programme", ["National", "International", "Vocational"])
            total_students = st.number_input("Nombre total d'étudiants*", min_value=1, value=500)
        
        with col3:
            total_teachers = st.number_input("Nombre d'enseignants*", min_value=1, value=30)
            total_classrooms = st.number_input("Nombre de salles de classe", min_value=1, value=20)
            total_area = st.number_input("Superficie totale (m²)", min_value=100, value=5000)
        
        st.markdown("### Données Académiques")
        col1, col2, col3 = st.columns(3)
        
        with col1:
            math_score = st.slider("Score moyen en Mathématiques", 0, 100, 70)
            science_score = st.slider("Score moyen en Sciences", 0, 100, 75)
        
        with col2:
            reading_score = st.slider("Score moyen en Lecture", 0, 100, 65)
            writing_score = st.slider("Score moyen en Écriture", 0, 100, 68)
        
        with col3:
            success_rate = st.slider("Taux de réussite (%)", 0, 100, 85)
            attendance_rate = st.slider("Taux de présence (%)", 0, 100, 92)
        
        st.markdown("### Données Financières")
        col1, col2, col3 = st.columns(3)
        
        with col1:
            annual_budget = st.number_input("Budget annuel total ($)", min_value=1000, value=1000000)
            per_student_spending = st.number_input("Dépenses par étudiant ($)", min_value=100, value=8000)
        
        with col2:
            teacher_salary = st.number_input("Salaire moyen des enseignants ($)", min_value=10000, value=45000)
            lab_count = st.number_input("Nombre de laboratoires", min_value=0, value=3)
        
        with col3:
            library_count = st.number_input("Nombre de bibliothèques", min_value=0, value=1)
            internet_access = st.selectbox("Accès Internet", [1, 0], format_func=lambda x: "Oui" if x == 1 else "Non")
        
        st.markdown("### Engagement et Ressources")
        col1, col2, col3 = st.columns(3)
        
        with col1:
            participation_rate = st.slider("Taux de participation (%)", 0, 100, 78)
            extracurricular_count = st.number_input("Activités extrascolaires", min_value=0, value=10)
        
        with col2:
            teacher_student_ratio = st.number_input("Ratio enseignant/étudiant", min_value=1, max_value=50, value=17)
            teacher_retention_rate = st.slider("Taux de rétention enseignants (%)", 0, 100, 88)
        
        with col3:
            training_hours = st.number_input("Heures de formation annuelles", min_value=0, value=40)
            satisfaction_score = st.slider("Score de satisfaction (1-10)", 1, 10, 7)
        
        # Bouton de soumission
        submitted = st.form_submit_button("Analyser l'École", use_container_width=True)
        
        if submitted:
            # Préparer les données
            input_data = {
                'School_Name': school_name,
                'Region': region,
                'School_Type': school_type,
                'Grades': grades,
                'Curriculum': curriculum,
                'Total_Students': total_students,
                'Total_Teachers': total_teachers,
                'Total_Classrooms': total_classrooms,
                'Total_Area': total_area,
                'Math_Score': math_score,
                'Science_Score': science_score,
                'Reading_Score': reading_score,
                'Writing_Score': writing_score,
                'Success_Rate': success_rate,
                'Attendance_Rate': attendance_rate,
                'Annual_Budget': annual_budget,
                'Per_Student_Spending': per_student_spending,
                'Teacher_Salary': teacher_salary,
                'Lab_Count': lab_count,
                'Library_Count': library_count,
                'Internet_Access': internet_access,
                'Participation_Rate': participation_rate,
                'Extracurricular_Count': extracurricular_count,
                'Teacher_Student_Ratio': teacher_student_ratio,
                'Teacher_Retention_Rate': teacher_retention_rate,
                'Training_Hours': training_hours,
                'Satisfaction_Score': satisfaction_score
            }
            
            # Faire la prédiction
            with st.spinner("Analyse en cours..."):
                prediction = predict_school_performance(input_data, models)
            
            if prediction:
                display_results(prediction, input_data, school_name)

def show_batch_analysis(models):
    st.markdown('<div class="section-header">Analyse par Fichier</div>', unsafe_allow_html=True)
    
    # Upload du fichier
    uploaded_file = st.file_uploader(
        "Choisissez un fichier Excel ou CSV",
        type=['xlsx', 'xls', 'csv'],
        help="Le fichier doit contenir les mêmes colonnes que le formulaire de saisie manuelle"
    )
    
    if uploaded_file is not None:
        try:
            # Lire le fichier
            if uploaded_file.name.endswith('.csv'):
                df = pd.read_csv(uploaded_file)
            else:
                df = pd.read_excel(uploaded_file)
            
            st.success(f"Fichier chargé avec succès! {len(df)} écoles trouvées.")
            
            # Afficher un aperçu
            st.markdown("### Aperçu des données")
            st.dataframe(df.head())
            
            # Analyse
            if st.button("Analyser toutes les écoles", use_container_width=True):
                with st.spinner("Analyse en cours..."):
                    results = []
                    for index, row in df.iterrows():
                        input_data = row.to_dict()
                        prediction = predict_school_performance(input_data, models)
                        if prediction:
                            results.append({
                                'school_name': input_data.get('School_Name', f'École {index+1}'),
                                'prediction': prediction['average']
                            })
                    
                    if results:
                        display_batch_results(results)
        
        except Exception as e:
            st.error(f"Erreur lors de la lecture du fichier: {e}")
    
    # Instructions
    st.markdown("### Instructions pour le fichier")
    st.info("""
    Le fichier doit contenir les colonnes suivantes:
    - School_Name (Nom de l'école)
    - Region (Région)
    - School_Type (Type d'école)
    - Grades (Niveaux)
    - Curriculum (Programme)
    - Total_Students (Nombre total d'étudiants)
    - Total_Teachers (Nombre d'enseignants)
    - Total_Classrooms (Nombre de salles de classe)
    - Total_Area (Superficie totale)
    - Math_Score (Score moyen en Mathématiques)
    - Science_Score (Score moyen en Sciences)
    - Reading_Score (Score moyen en Lecture)
    - Writing_Score (Score moyen en Écriture)
    - Success_Rate (Taux de réussite)
    - Attendance_Rate (Taux de présence)
    - Annual_Budget (Budget annuel total)
    - Per_Student_Spending (Dépenses par étudiant)
    - Teacher_Salary (Salaire moyen des enseignants)
    - Lab_Count (Nombre de laboratoires)
    - Library_Count (Nombre de bibliothèques)
    - Internet_Access (Accès Internet)
    - Participation_Rate (Taux de participation)
    - Extracurricular_Count (Activités extrascolaires)
    - Teacher_Student_Ratio (Ratio enseignant/étudiant)
    - Teacher_Retention_Rate (Taux de rétention enseignants)
    - Training_Hours (Heures de formation annuelles)
    - Satisfaction_Score (Score de satisfaction)
    """)

def display_results(prediction, input_data, school_name):
    st.markdown('<div class="section-header">Résultats de l\'Analyse</div>', unsafe_allow_html=True)
    
    # Score principal
    col1, col2, col3 = st.columns([1, 2, 1])
    
    with col1:
        st.empty()
    
    with col2:
        # Jauge de performance
        fig = go.Figure(go.Indicator(
            mode = "gauge+number+delta",
            value = prediction['average'],
            domain = {'x': [0, 1], 'y': [0, 1]},
            title = {'text': f"Score de Performance - {school_name}"},
            delta = {'reference': 70},
            gauge = {
                'axis': {'range': [None, 100]},
                'bar': {'color': "darkblue"},
                'steps': [
                    {'range': [0, 40], 'color': "lightgray"},
                    {'range': [40, 70], 'color': "gray"},
                    {'range': [70, 100], 'color': "lightgreen"}
                ],
                'threshold': {
                    'line': {'color': "red", 'width': 4},
                    'thickness': 0.75,
                    'value': 90
                }
            }
        ))
        
        fig.update_layout(height=400)
        st.plotly_chart(fig, use_container_width=True)
    
    with col3:
        st.empty()
    
    # Recommandations stratégiques
    recommendations, level, color = generate_strategic_recommendations(prediction, input_data)
    
    st.markdown("### Recommandations Stratégiques")
    
    # Afficher les recommandations par catégorie
    for key, rec in recommendations.items():
        with st.expander(rec['title']):
            for action in rec['actions']:
                st.write(f"  - {action}")
    
    # Importance des caractéristiques
    st.markdown("### Facteurs Clés de Performance")
    
    feature_importance = models['feature_importance']
    feature_names = models['feature_names']
    
    importance_df = pd.DataFrame({
        'feature': feature_names,
        'importance': feature_importance
    }).sort_values('importance', ascending=False).head(10)
    
    fig = px.bar(
        importance_df,
        x='importance',
        y='feature',
        orientation='h',
        title="Top 10 des Facteurs d'Influence"
    )
    fig.update_layout(height=400)
    st.plotly_chart(fig, use_container_width=True)
    
    # Export des résultats
    st.markdown("### Exporter les Résultats")
    
    results_df = pd.DataFrame({
        'École': [school_name],
        'Score_RF': [prediction['random_forest']],
        'Score_XGB': [prediction['xgboost']],
        'Score_Moyen': [prediction['average']],
        'Niveau': [level]
    })
    
    csv = results_df.to_csv(index=False)
    st.download_button(
        label="Télécharger les résultats (CSV)",
        data=csv,
        file_name=f"results_{school_name}.csv",
        mime="text/csv"
    )

def display_batch_results(results):
    st.markdown('<div class="section-header">Résultats de l\'Analyse par Lot</div>', unsafe_allow_html=True)
    
    # DataFrame des résultats
    results_df = pd.DataFrame(results)
    
    # Statistiques
    col1, col2, col3, col4 = st.columns(4)
    
    with col1:
        st.metric("Écoles Analysées", len(results))
    
    with col2:
        avg_score = results_df['prediction'].mean()
        st.metric("Score Moyen", f"{avg_score:.2f}")
    
    with col3:
        max_score = results_df['prediction'].max()
        st.metric("Meilleur Score", f"{max_score:.2f}")
    
    with col4:
        min_score = results_df['prediction'].min()
        st.metric("Score Minimum", f"{min_score:.2f}")
    
    # Graphique des résultats
    fig = px.histogram(
        results_df,
        x='prediction',
        nbins=20,
        title="Distribution des Scores de Performance"
    )
    fig.update_layout(height=400)
    st.plotly_chart(fig, use_container_width=True)
    
    # Tableau des résultats
    st.markdown("### Résultats Détaillés")
    st.dataframe(results_df)
    
    # Export
    csv = results_df.to_csv(index=False)
    st.download_button(
        label="Télécharger tous les résultats (CSV)",
        data=csv,
        file_name="batch_results.csv",
        mime="text/csv"
    )

def show_about_page():
    st.markdown('<div class="section-header">À Propos du Système</div>', unsafe_allow_html=True)
    
    st.markdown("### Qu'est-ce que l'AI Educational Transformation System?")
    st.write("""
    Ce système utilise l'intelligence artificielle pour analyser et améliorer la performance des écoles.
    Il combine des techniques avancées de machine learning avec une interface intuitive pour fournir
    des analyses complètes et des recommandations actionnables.
    """)
    
    st.markdown("### Caractéristiques Principales")
    st.write("""
    - **Analyse Prédictive**: Utilise Random Forest et XGBoost pour des prédictions précises
    - **Interface Intuitive**: Facile à utiliser pour les éducateurs et administrateurs
    - **Support Multilingue**: Interface en français avec support arabe
    - **Visualisations Interactives**: Graphiques et tableaux de bord dynamiques
    - **Recommandations Personnalisées**: Stratégies adaptées à chaque école
    """)
    
    st.markdown("### Technologies Utilisées")
    st.write("""
    - **Machine Learning**: Random Forest, XGBoost
    - **Interface**: Streamlit
    - **Visualisations**: Plotly
    - **Traitement**: Pandas, NumPy
    - **Déploiement**: Python, Joblib
    """)
    
    st.markdown("### Contact")
    st.write("""
    Pour plus d'informations ou pour obtenir du support technique,
    veuillez contacter l'équipe de développement.
    """)

if __name__ == "__main__":
    main()
